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
    }
}
