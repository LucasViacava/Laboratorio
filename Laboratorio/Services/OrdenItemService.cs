using Laboratorio.Data;
using Laboratorio.DTOs;
using Laboratorio.Entities;
using Microsoft.EntityFrameworkCore;

namespace Laboratorio.Services
{
    public class OrdenItemService
    {
        private readonly RestauranteContext _context;

        public OrdenItemService(RestauranteContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<OrdenItem>> ObtenerOrdenItems()
        {
            return await _context.OrdenItems.ToListAsync();
        }

        public async Task<OrdenItem?> ObtenerOrdenItemPorId(int id)
        {
            return await _context.OrdenItems.FindAsync(id);
        }

        public async Task<OrdenItem> CrearOrdenItem(OrdenItemDTO ordenItemDTO)
        {
            var ordenItem = new OrdenItem
            {
                OrdenId = ordenItemDTO.OrdenId,
                MenuItemId = ordenItemDTO.MenuItemId,
                Cantidad = ordenItemDTO.Cantidad,
                Precio = ordenItemDTO.Precio
            };

            _context.OrdenItems.Add(ordenItem);
            await _context.SaveChangesAsync();
            return ordenItem;
        }

        public async Task<bool> ActualizarOrdenItem(int id, OrdenItemDTO ordenItemDTO)
        {
            var ordenItem = await ObtenerOrdenItemPorId(id);
            if (ordenItem == null) return false;

            ordenItem.OrdenId = ordenItemDTO.OrdenId;
            ordenItem.MenuItemId = ordenItemDTO.MenuItemId;
            ordenItem.Cantidad = ordenItemDTO.Cantidad;
            ordenItem.Precio = ordenItemDTO.Precio;

            _context.Entry(ordenItem).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> EliminarOrdenItem(int id)
        {
            var ordenItem = await ObtenerOrdenItemPorId(id);
            if (ordenItem == null) return false;

            _context.OrdenItems.Remove(ordenItem);
            await _context.SaveChangesAsync();
            return true;
        }

        public bool OrdenItemExiste(int id)
        {
            return _context.OrdenItems.Any(e => e.Id == id);
        }
    }
}
