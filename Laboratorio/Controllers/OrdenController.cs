using Laboratorio.DTOs;
using Laboratorio.Entities;
using Laboratorio.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Laboratorio.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrdenController : ControllerBase
    {
        private readonly OrdenService _ordenService;

        public OrdenController(OrdenService ordenService)
        {
            _ordenService = ordenService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Orden>>> GetOrdenes()
        {
            var ordenes = await _ordenService.ObtenerOrdenes();
            return Ok(ordenes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Orden?>> GetOrden(int id)
        {
            var orden = await _ordenService.ObtenerOrdenPorId(id);

            if (orden == null)
            {
                return NotFound();
            }

            return Ok(orden);
        }

        [HttpPost]
        public async Task<ActionResult<Orden>> PostOrden(OrdenDTO ordenDTO)
        {
            var nuevaOrden = await _ordenService.CrearOrden(ordenDTO);
            return CreatedAtAction(nameof(GetOrden), new { id = nuevaOrden.Id }, nuevaOrden);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrden(int id, OrdenDTO ordenDTO)
        {
            var actualizado = await _ordenService.ActualizarOrden(id, ordenDTO);

            if (!actualizado)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrden(int id)
        {
            var eliminado = await _ordenService.EliminarOrden(id);

            if (!eliminado)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
