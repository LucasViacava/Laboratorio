using Laboratorio.DTOs;
using Laboratorio.Entities;
using Laboratorio.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Laboratorio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MesaController : ControllerBase
    {
        private readonly MesaService _mesaService;

        public MesaController(MesaService mesaService)
        {
            _mesaService = mesaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mesa>>> GetMesas()
        {
            var mesas = await _mesaService.ObtenerMesas();
            return Ok(mesas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Mesa?>> GetMesa(int id)
        {
            var mesa = await _mesaService.ObtenerMesaPorId(id);

            if (mesa == null)
            {
                return NotFound();
            }

            return Ok(mesa);
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Mesa>> PostMesa(MesaDTO mesaDTO)
        {
            var nuevaMesa = await _mesaService.CrearMesa(mesaDTO);
            return CreatedAtAction(nameof(GetMesa), new { id = nuevaMesa.Id }, nuevaMesa);
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMesa(int id, MesaDTO mesaDTO)
        {
            var actualizado = await _mesaService.ActualizarMesa(id, mesaDTO);

            if (!actualizado)
            {
                return NotFound();
            }

            return NoContent();
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMesa(int id)
        {
            var eliminado = await _mesaService.EliminarMesa(id);

            if (!eliminado)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
