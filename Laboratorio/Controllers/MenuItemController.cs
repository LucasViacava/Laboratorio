using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Laboratorio.Entities;
using Laboratorio.Data;
using AutoMapper;
using Laboratorio.DTOs;
namespace Laboratorio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuItemController : ControllerBase
    {
        private readonly RestauranteContext _context;

        private readonly IMapper _mapper;

        public MenuItemController(RestauranteContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MenuItem>>> GetMenuItems()
        {
            return await _context.MenuItems.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MenuItem?>> GetMenuItem(int id)
        {
            var menuItem = await _context.MenuItems.FindAsync(id);

            if (menuItem == null)
            {
                return NotFound();
            }

            return menuItem;
        }

        [HttpPost]
        public async Task<ActionResult<MenuItem>> PostMenuItem(MenuItemDTO menuItemDTO)
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

            return CreatedAtAction(nameof(GetMenuItem), new { id = menuItem.Id }, menuItem);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutMenuItem(int id, MenuItemDTO menuItemDTO)
        {
            var menuItem = await _context.MenuItems.FindAsync(id);
            if (menuItem == null)
            {
                return NotFound();
            }

            menuItem.Nombre = menuItemDTO.Nombre;
            menuItem.Descripcion = menuItemDTO.Descripcion;
            menuItem.Precio = menuItemDTO.Precio;
            menuItem.Categoria = menuItemDTO.Categoria;

            _context.Entry(menuItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MenuItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMenuItem(int id)
        {
            var menuItem = await _context.MenuItems.FindAsync(id);
            if (menuItem == null)
            {
                return NotFound();
            }

            _context.MenuItems.Remove(menuItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MenuItemExists(int id)
        {
            return _context.MenuItems.Any(e => e.Id == id);
        }
    }
}
