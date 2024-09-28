using Laboratorio.DTOs;
using Laboratorio.Entities;
using Laboratorio.Services;
using Microsoft.AspNetCore.Mvc;

namespace Laboratorio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservaController : ControllerBase
    {
        private readonly ReservaService _reservaService;

        public ReservaController(ReservaService reservaService)
        {
            _reservaService = reservaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reserva>>> GetReservas()
        {
            var reservas = await _reservaService.ObtenerReservas();
            return Ok(reservas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Reserva?>> GetReserva(int id)
        {
            var reserva = await _reservaService.ObtenerReservaPorId(id);

            if (reserva == null)
            {
                return NotFound();
            }

            return Ok(reserva);
        }

        [HttpPost]
        public async Task<ActionResult<Reserva>> PostReserva(ReservaDTO reservaDTO)
        {
            var nuevaReserva = await _reservaService.CrearReserva(reservaDTO);
            return CreatedAtAction(nameof(GetReserva), new { id = nuevaReserva.Id }, nuevaReserva);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutReserva(int id, ReservaDTO reservaDTO)
        {
            var actualizado = await _reservaService.ActualizarReserva(id, reservaDTO);

            if (!actualizado)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReserva(int id)
        {
            var eliminado = await _reservaService.EliminarReserva(id);

            if (!eliminado)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
