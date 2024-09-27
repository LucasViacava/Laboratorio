using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Laboratorio.Entities;
using Laboratorio.Data;
using AutoMapper;
using Laboratorio.DTOs;
using Microsoft.AspNetCore.Authorization;
namespace Laboratorio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MesaController : ControllerBase
    {
        private readonly RestauranteContext _context;

        private readonly IMapper _mapper;

        public MesaController(RestauranteContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mesa>>> GetMesas()
        {
            return await _context.Mesas.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Mesa?>> GetMesa(int id)
        {
            var mesa = await _context.Mesas.FindAsync(id);

            if (mesa == null)
            {
                return NotFound();
            }

            return mesa;
        }
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Mesa>> PostMesa(MesaDTO mesaDTO)
        {
            var mesa = new Mesa
            {
                Numero = mesaDTO.Numero,
                Capacidad = mesaDTO.Capacidad,
                Ubicacion = mesaDTO.Ubicacion
            };

            _context.Mesas.Add(mesa);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMesa), new { id = mesa.Id }, mesa);
        }
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMesa(int id, MesaDTO mesaDTO)
        {
            var mesa = await _context.Mesas.FindAsync(id);
            if (mesa == null)
            {
                return NotFound();
            }

            mesa.Numero = mesaDTO.Numero;
            mesa.Capacidad = mesaDTO.Capacidad;
            mesa.Ubicacion = mesaDTO.Ubicacion;

            _context.Entry(mesa).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MesaExists(id))
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
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMesa(int id)
        {
            var mesa = await _context.Mesas.FindAsync(id);
            if (mesa == null)
            {
                return NotFound();
            }

            _context.Mesas.Remove(mesa);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MesaExists(int id)
        {
            return _context.Mesas.Any(e => e.Id == id);
        }
    }
}
