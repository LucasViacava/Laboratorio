using Laboratorio.DTOs;
using Laboratorio.Entities;
using Laboratorio.Services;
using Microsoft.AspNetCore.Mvc;

namespace Laboratorio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdenItemController : ControllerBase
    {
        private readonly OrdenItemService _ordenItemService;

        public OrdenItemController(OrdenItemService ordenItemService)
        {
            _ordenItemService = ordenItemService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrdenItem>>> GetOrdenItems()
        {
            var ordenItems = await _ordenItemService.ObtenerOrdenItems();
            return Ok(ordenItems);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrdenItem?>> GetOrdenItem(int id)
        {
            var ordenItem = await _ordenItemService.ObtenerOrdenItemPorId(id);

            if (ordenItem == null)
            {
                return NotFound();
            }

            return Ok(ordenItem);
        }

        [HttpPost]
        public async Task<ActionResult<OrdenItem>> PostOrdenItem(OrdenItemDTO ordenItemDTO)
        {
            var nuevoOrdenItem = await _ordenItemService.CrearOrdenItem(ordenItemDTO);
            return CreatedAtAction(nameof(GetOrdenItem), new { id = nuevoOrdenItem.Id }, nuevoOrdenItem);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrdenItem(int id, OrdenItemDTO ordenItemDTO)
        {
            var actualizado = await _ordenItemService.ActualizarOrdenItem(id, ordenItemDTO);

            if (!actualizado)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrdenItem(int id)
        {
            var eliminado = await _ordenItemService.EliminarOrdenItem(id);

            if (!eliminado)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
