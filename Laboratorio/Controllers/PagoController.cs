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
    public class PagoController : ControllerBase
    {
        private readonly RestauranteContext _context;

        private readonly IMapper _mapper;

        public PagoController(RestauranteContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pago>>> GetPagos()
        {
            return await _context.Pagos.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Pago?>> GetPago(int id)
        {
            var pago = await _context.Pagos.FindAsync(id);

            if (pago == null)
            {
                return NotFound();
            }

            return pago;
        }

        [HttpPost]
        public async Task<ActionResult<Pago>> PostPago(PagoDTO pagoDTO)
        {
            var pago = new Pago
            {
                OrdenId = pagoDTO.OrdenId,
                Monto = pagoDTO.Monto,
                Metodo = pagoDTO.Metodo,
                FechaPago = pagoDTO.FechaPago
            };

            _context.Pagos.Add(pago);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPago), new { id = pago.Id }, pago);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPago(int id, PagoDTO pagoDTO)
        {
            var pago = await _context.Pagos.FindAsync(id);
            if (pago == null)
            {
                return NotFound();
            }

            pago.OrdenId = pagoDTO.OrdenId;
            pago.Monto = pagoDTO.Monto;
            pago.Metodo = pagoDTO.Metodo;
            pago.FechaPago = pagoDTO.FechaPago;

            _context.Entry(pago).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PagoExists(id))
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
        public async Task<IActionResult> DeletePago(int id)
        {
            var pago = await _context.Pagos.FindAsync(id);
            if (pago == null)
            {
                return NotFound();
            }

            _context.Pagos.Remove(pago);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PagoExists(int id)
        {
            return _context.Pagos.Any(e => e.Id == id);
        }
    }
}
