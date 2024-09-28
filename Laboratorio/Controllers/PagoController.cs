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
    public class PagoController : ControllerBase
    {
        private readonly PagoService _pagoService;

        public PagoController(PagoService pagoService)
        {
            _pagoService = pagoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pago>>> GetPagos()
        {
            var pagos = await _pagoService.ObtenerPagos();
            return Ok(pagos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Pago?>> GetPago(int id)
        {
            var pago = await _pagoService.ObtenerPagoPorId(id);

            if (pago == null)
            {
                return NotFound();
            }

            return Ok(pago);
        }

        [HttpPost]
        public async Task<ActionResult<Pago>> PostPago(PagoDTO pagoDTO)
        {
            var nuevoPago = await _pagoService.CrearPago(pagoDTO);
            return CreatedAtAction(nameof(GetPago), new { id = nuevoPago.Id }, nuevoPago);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPago(int id, PagoDTO pagoDTO)
        {
            var actualizado = await _pagoService.ActualizarPago(id, pagoDTO);

            if (!actualizado)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePago(int id)
        {
            var eliminado = await _pagoService.EliminarPago(id);

            if (!eliminado)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
