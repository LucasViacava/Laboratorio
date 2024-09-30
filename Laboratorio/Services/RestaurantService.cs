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

            return orden.Id;
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
                    OrdenId = c.Orden.Id,
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

            comanda.Estado = "En Preparación";
            comanda.FechaCreacion = DateTimeOffset.Now;

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
        public async Task<List<ComandaDTO>> GetPendingProductsForEmployeeAsync(int empleadoId)
        {
            var comandasPendientes = await _context.Ordenes
                .Where(o => o.EmpleadoId == empleadoId)
                .Include(o => o.OrdenItems)
                .ThenInclude(oi => oi.MenuItem)
                .Include(o => o.Comandas)
                .SelectMany(o => o.Comandas)
                .Where(c => c.Estado == "Pendiente")
                .Select(c => new ComandaDTO
                {
                    Id = c.Id,
                    MenuItemId = c.MenuItemId,
                    Estado = c.Estado,
                    FechaCreacion = c.FechaCreacion,
                    MenuItemNombre = c.MenuItem.Nombre,
                    Cantidad = c.Cantidad
                })
                .ToListAsync();

            return comandasPendientes;
        }
        public async Task<bool> UpdateProductStatusAsync(int comandaId, string estado)
        {
            var comanda = await _context.Comandas.FirstOrDefaultAsync(c => c.Id == comandaId);
            if (comanda == null)
            {
                throw new Exception($"No se encontró la comanda con ID {comandaId}.");
            }

            comanda.Estado = estado;
            _context.Comandas.Update(comanda);
            var result = await _context.SaveChangesAsync();

            return result > 0;
        }
        public async Task<bool> UpdateMesaStatusForReadyOrdersAsync(int mesaId)
        {
            var mesa = await _context.Mesas.FirstOrDefaultAsync(m => m.Id == mesaId);
            if (mesa == null)
            {
                throw new Exception($"La mesa con ID {mesaId} no existe.");
            }

            var ordenes = await _context.Ordenes
                .Include(o => o.Comandas)
                .Where(o => o.MesaId == mesaId && o.Estado == EstadoHelper.GetEstadoAsString(EstadoHelper.EEstado.EnPreparacion))
                .ToListAsync();

            if (!ordenes.Any())
            {
                throw new Exception($"No hay órdenes en preparación para la mesa {mesaId}.");
            }

            bool actualizacionRealizada = false;

            foreach (var orden in ordenes)
            {
                var todasListas = orden.Comandas.All(c => c.Estado == "Listo para Servir");
                if (todasListas)
                {
                    orden.Estado = EstadoHelper.GetEstadoAsString(EstadoHelper.EEstado.Finalizado);
                    orden.FechaFinalizacion = DateTimeOffset.Now;
                    actualizacionRealizada = true;
                }
            }

            if (!actualizacionRealizada)
            {
                throw new Exception("No se encontraron órdenes listas para finalizar en esta mesa.");
            }

            _context.Ordenes.UpdateRange(ordenes);

            var result = await _context.SaveChangesAsync();
            return result > 0;
        }
        public async Task<List<MesaEstadoDTO>> GetMesasWithStatusAsync()
        {
            var mesas = await _context.Mesas.ToListAsync();

            var ordenesPorMesa = await _context.Ordenes
                .Where(o => o.MesaId.HasValue)
                .ToListAsync();

            var ordenesAgrupadas = ordenesPorMesa
                .GroupBy(o => o.MesaId.Value)
                .ToDictionary(g => g.Key, g => g.ToList());

            var mesasConEstado = mesas.Select(m => new MesaEstadoDTO
            {
                MesaId = m.Id,
                Numero = m.Numero,
                Ubicacion = m.Ubicacion,
                Estado = DeterminarEstadoMesa(m.Id, ordenesAgrupadas)
            }).ToList();

            return mesasConEstado;
        }

        private string DeterminarEstadoMesa(int mesaId, Dictionary<int, List<Orden>> ordenesPorMesa)
        {
            if (!ordenesPorMesa.ContainsKey(mesaId) || !ordenesPorMesa[mesaId].Any())
            {
                return "Disponible";
            }

            var ordenes = ordenesPorMesa[mesaId];

            if (ordenes.All(o => o.Estado == EstadoHelper.GetEstadoAsString(EstadoHelper.EEstado.Finalizado) ||
                                 o.Estado == EstadoHelper.GetEstadoAsString(EstadoHelper.EEstado.Cancelado)))
            {
                return "Disponible";
            }

            if (ordenes.Any(o => o.Estado == EstadoHelper.GetEstadoAsString(EstadoHelper.EEstado.EnPreparacion)))
            {
                return "En Preparación";
            }

            if (ordenes.Any(o => o.Estado == EstadoHelper.GetEstadoAsString(EstadoHelper.EEstado.Pendiente)))
            {
                return "Pendiente";
            }

            return "Ocupada";
        }
        public async Task<bool> CobrarCuentaAsync(int ordenId, string metodoPago)
        {
            var orden = await _context.Ordenes
                .Include(o => o.Comandas)
                .FirstOrDefaultAsync(o => o.Id == ordenId);

            if (orden == null)
            {
                throw new Exception($"La orden con ID {ordenId} no existe.");
            }

            if (orden.Estado == EstadoHelper.GetEstadoAsString(EstadoHelper.EEstado.Finalizado))
            {
                throw new Exception($"La orden con ID {ordenId} ya ha sido finalizada.");
            }

            orden.Estado = EstadoHelper.GetEstadoAsString(EstadoHelper.EEstado.Finalizado);
            orden.FechaFinalizacion = DateTimeOffset.Now;

            foreach (var comanda in orden.Comandas)
            {
                comanda.Estado = EstadoHelper.GetEstadoAsString(EstadoHelper.EEstado.Finalizado);
            }

            var pago = new Pago
            {
                OrdenId = ordenId,
                Monto = orden.MontoTotal,
                Metodo = metodoPago,
                FechaPago = DateTimeOffset.Now
            };

            await _context.Pagos.AddAsync(pago);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }
    }
}
