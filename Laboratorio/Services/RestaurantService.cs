using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Laboratorio.Data;
using Laboratorio.DTOs;
using Laboratorio.Entities;
using Microsoft.EntityFrameworkCore;

namespace Laboratorio.Services
{
    public class RestaurantService : IRestaurantService
    {
        private readonly RestauranteContext _context;

        public RestaurantService(RestauranteContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateOrderAsync(CreateOrderDTO orderRequest)
        {
            //{
            //  "createdBy": "Juan Perez",
            //  "menuItems": [
            //    {
            //                    "plato": "Milanesa a Caballo",
            //      "cantidad": 1
            //    },
            //    {
            //                    "plato": "Hamburguesa de Garbanzo",
            //      "cantidad": 2
            //    },
            //    {
            //                    "plato": "Corona",
            //      "cantidad": 1
            //    },
            //    {
            //                    "plato": "Daikiri",
            //      "cantidad": 1
            //    }
            //  ],
            //  "mesa": 1
            //}
            var mesa = _context.Mesas.FirstOrDefault(m => m.Id == orderRequest.Mesa);
            if (mesa == null)
            {
                throw new Exception($"La mesa con ID {orderRequest.Mesa} no existe.");
            }

            var empleado = await _context.Empleados
                .Where(e => e.Nombre.ToLower() == orderRequest.CreatedBy.ToLower())
                .FirstOrDefaultAsync();
            if (empleado == null)
            {
                throw new Exception($"El empleado '{orderRequest.CreatedBy}' no existe.");
            }

            var menuItemsValidos = await _context.MenuItems.ToListAsync();
            var ordenItems = new List<OrdenItem>();

            foreach (var item in orderRequest.MenuItems)
            {
                var menuItem = menuItemsValidos
                    .FirstOrDefault(mi => mi.Nombre.Equals(item.Plato, StringComparison.OrdinalIgnoreCase));

                if (menuItem == null)
                {
                    throw new Exception($"El item '{item.Plato}' no existe en el menú.");
                }

                if (ordenItems.Any(oi => oi.MenuItemId == menuItem.Id))
                {
                    throw new Exception($"El item '{item.Plato}' ya está registrado en la orden. No se permiten duplicados.");
                }

                ordenItems.Add(new OrdenItem
                {
                    MenuItemId = menuItem.Id,
                    Cantidad = item.Cantidad,
                    Precio = menuItem.Precio
                });
            }

            var ordenExistente = _context.Ordenes
                .FirstOrDefault(o => o.MesaId == orderRequest.Mesa && o.EmpleadoId == empleado.Id && (o.Estado == "Pendiente" || o.Estado == "En Preparación"));

            if (ordenExistente != null)
            {
                throw new Exception($"Ya existe una orden pendiente para la mesa {orderRequest.Mesa} creada por {orderRequest.CreatedBy}.");
            }

            decimal montoTotal = ordenItems.Sum(oi => oi.Precio * oi.Cantidad);

            var orden = new Orden
            {
                MesaId = orderRequest.Mesa,
                EmpleadoId = empleado.Id,
                Estado = "Pendiente",
                FechaCreacion = DateTime.Now,
                OrdenItems = ordenItems,
                MontoTotal = montoTotal
            };

            await _context.Ordenes.AddAsync(orden);
            var result = await _context.SaveChangesAsync();

            var comandas = ordenItems.Select(oi => new Comanda
            {
                OrdenId = orden.Id,
                MenuItemId = oi.MenuItemId,
                Cantidad = oi.Cantidad,
                Estado = "Pendiente",
                FechaCreacion = DateTime.Now
            }).ToList();

            await _context.Comandas.AddRangeAsync(comandas);
            await _context.SaveChangesAsync();

            return result > 0;
        }
        public async Task<List<ComandaDTO>> GetPendingOrdersForEmployeeAsync(int empleadoId)
        {
            var comandasPendientes = await _context.Comandas
                .Include(c => c.MenuItem)
                .Include(c => c.Orden)
                .Where(c => c.Estado == "Pendiente" && c.Orden.EmpleadoId == empleadoId)
                .Select(c => new ComandaDTO
                {
                    Id = c.Id,
                    MenuItemId = c.MenuItemId,
                    MenuItemNombre = c.MenuItem.Nombre,
                    Cantidad = c.Cantidad,
                    Estado = c.Estado,
                    FechaCreacion = c.FechaCreacion
                })
                .ToListAsync();

            return comandasPendientes;
        }


        public async Task<bool> UpdateOrderStatusToInPreparationAsync(int comandaId)
        {
            var comanda = await _context.Comandas.Include(c => c.MenuItem).FirstOrDefaultAsync(c => c.Id == comandaId);
            if (comanda == null)
            {
                throw new Exception($"La comanda con ID {comandaId} no existe.");
            }

            // Cambiar el estado y calcular el tiempo de preparación
            comanda.Estado = "En Preparación";
            comanda.FechaCreacion = DateTimeOffset.Now;

            // Guardar cambios
            _context.Comandas.Update(comanda);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<string> GetOrderPreparationTimeAsync(int mesaId, int ordenId)
        {
            var orden = await _context.Ordenes
                .Include(o => o.OrdenItems).ThenInclude(oi => oi.MenuItem)
                .FirstOrDefaultAsync(o => o.Id == ordenId && o.MesaId == mesaId);

            if (orden == null)
            {
                throw new Exception($"No se encontró la orden con ID {ordenId} para la mesa {mesaId}.");
            }

            var tiempoTotalPreparacion = orden.OrdenItems.Max(oi => oi.MenuItem.TiempoPreparacion);

            var tiempoTranscurrido = DateTime.Now - orden.FechaCreacion;

            var tiempoRestante = tiempoTotalPreparacion - (int)tiempoTranscurrido.TotalMinutes;

            if (tiempoRestante > 0)
            {
                return $"El tiempo total de preparación es de {tiempoTotalPreparacion} minutos. Tiempo restante: {tiempoRestante} minutos.";
            }
            else
            {
                var tiempoExcedido = Math.Abs(tiempoRestante);
                return $"Se excedio el tiempo de preparación. Tiempo total de preparación era de {tiempoTotalPreparacion} minutos. " +
                       $"Tiempo excedido: {tiempoExcedido} minutos.";
            }
        }

        public async Task<List<OrdenInfoDTO>> GetOrderDetailsWithDelaysAsync()
        {
            var ordenes = await _context.Ordenes
                .Include(o => o.OrdenItems)
                .ThenInclude(oi => oi.MenuItem)
                .Include(o => o.Empleado)
                .ToListAsync();

            var ordenesConTiempo = ordenes.Select(o => new OrdenInfoDTO
            {
                OrdenId = o.Id,
                MesaId = o.MesaId,
                EmpleadoNombre = o.Empleado?.Nombre,
                Estado = o.Estado,
                FechaCreacion = o.FechaCreacion,
                FechaFinalizacion = o.FechaFinalizacion,
                TiempoTotalPreparacion = CalcularTiempoDemora(o)
            }).ToList();

            return ordenesConTiempo;
        }
        private int CalcularTiempoDemora(Orden orden)
        {
            var fechaFinal = orden.FechaFinalizacion ?? DateTimeOffset.Now;
            var tiempoTotal = (int)(fechaFinal - orden.FechaCreacion).TotalMinutes;

            return tiempoTotal;
        }

    }
}
