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
    public class ReservaController : ControllerBase
    {
        private readonly RestauranteContext _context;

        private readonly IMapper _mapper;

        public ReservaController(RestauranteContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reserva>>> GetReservas()
        {
            return await _context.Reservas.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Reserva?>> GetReserva(int id)
        {
            var reserva = await _context.Reservas.FindAsync(id);

            if (reserva == null)
            {
                return NotFound();
            }

            return reserva;
        }

        [HttpPost]
        public async Task<ActionResult<Reserva>> PostReserva(ReservaDTO reservaDTO)
        {
            var reserva = new Reserva
            {
                NombreCliente = reservaDTO.NombreCliente,
                MesaId = reservaDTO.MesaId,
                FechaReserva = reservaDTO.FechaReserva
            };
            _context.Reservas.Add(reserva);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetReserva), new { id = reserva.Id }, reserva);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutReserva(int id, ReservaDTO reservaDTO)
        {
            var reserva = await _context.Reservas.FindAsync(id);
            if (reserva == null)
            {
                return NotFound();
            }

            reserva.NombreCliente = reservaDTO.NombreCliente;
            reserva.MesaId = reservaDTO.MesaId;
            reserva.FechaReserva = reservaDTO.FechaReserva;

            _context.Entry(reserva).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReservaExists(id))
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
        public async Task<IActionResult> DeleteReserva(int id)
        {
            var reserva = await _context.Reservas.FindAsync(id);
            if (reserva == null)
            {
                return NotFound();
            }

            _context.Reservas.Remove(reserva);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ReservaExists(int id)
        {
            return _context.Reservas.Any(e => e.Id == id);
        }
    }
}
