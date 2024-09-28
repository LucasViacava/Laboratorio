using Laboratorio.DTOs;
using Laboratorio.Entities;
using Laboratorio.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Laboratorio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuItemController : ControllerBase
    {
        private readonly MenuItemService _menuItemService;

        public MenuItemController(MenuItemService menuItemService)
        {
            _menuItemService = menuItemService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MenuItem>>> GetMenuItems()
        {
            var menuItems = await _menuItemService.ObtenerMenuItems();
            return Ok(menuItems);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MenuItem?>> GetMenuItem(int id)
        {
            var menuItem = await _menuItemService.ObtenerMenuItemPorId(id);

            if (menuItem == null)
            {
                return NotFound();
            }

            return Ok(menuItem);
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<MenuItem>> PostMenuItem(MenuItemDTO menuItemDTO)
        {
            var nuevoMenuItem = await _menuItemService.CrearMenuItem(menuItemDTO);
            return CreatedAtAction(nameof(GetMenuItem), new { id = nuevoMenuItem.Id }, nuevoMenuItem);
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMenuItem(int id, MenuItemDTO menuItemDTO)
        {
            var actualizado = await _menuItemService.ActualizarMenuItem(id, menuItemDTO);

            if (!actualizado)
            {
                return NotFound();
            }

            return NoContent();
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMenuItem(int id)
        {
            var eliminado = await _menuItemService.EliminarMenuItem(id);

            if (!eliminado)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
