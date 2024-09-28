using Laboratorio.Data;
using Laboratorio.DTOs;
using Laboratorio.Entities;
using Microsoft.EntityFrameworkCore;

namespace Laboratorio.Services
{
    public class MenuItemService
    {
        private readonly RestauranteContext _context;

        public MenuItemService(RestauranteContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MenuItem>> ObtenerMenuItems()
        {
            return await _context.MenuItems.ToListAsync();
        }

        public async Task<MenuItem?> ObtenerMenuItemPorId(int id)
        {
            return await _context.MenuItems.FindAsync(id);
        }

        public async Task<MenuItem> CrearMenuItem(MenuItemDTO menuItemDTO)
        {
            var menuItem = new MenuItem
            {
                Nombre = menuItemDTO.Nombre,
                Descripcion = menuItemDTO.Descripcion,
                Precio = menuItemDTO.Precio,
                Categoria = menuItemDTO.Categoria
            };

            _context.MenuItems.Add(menuItem);
            await _context.SaveChangesAsync();
            return menuItem;
        }

        public async Task<bool> ActualizarMenuItem(int id, MenuItemDTO menuItemDTO)
        {
            var menuItem = await ObtenerMenuItemPorId(id);
            if (menuItem == null) return false;

            menuItem.Nombre = menuItemDTO.Nombre;
            menuItem.Descripcion = menuItemDTO.Descripcion;
            menuItem.Precio = menuItemDTO.Precio;
            menuItem.Categoria = menuItemDTO.Categoria;

            _context.Entry(menuItem).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> EliminarMenuItem(int id)
        {
            var menuItem = await ObtenerMenuItemPorId(id);
            if (menuItem == null) return false;

            _context.MenuItems.Remove(menuItem);
            await _context.SaveChangesAsync();
            return true;
        }

        public bool MenuItemExiste(int id)
        {
            return _context.MenuItems.Any(e => e.Id == id);
        }
    }
}
