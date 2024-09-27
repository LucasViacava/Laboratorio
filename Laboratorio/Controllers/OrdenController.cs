using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Laboratorio.Entities;
using Laboratorio.Data;
using AutoMapper;
using Laboratorio.DTOs;
using Microsoft.AspNetCore.Authorization;
namespace Laboratorio.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrdenController : ControllerBase
    {
        private readonly RestauranteContext _context;

        private readonly IMapper _mapper;

        public OrdenController(RestauranteContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Orden>>> GetOrdenes()
        {
            return await _context.Ordenes.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Orden?>> GetOrden(int id)
        {
            var orden = await _context.Ordenes.FindAsync(id);

            if (orden == null)
            {
                return NotFound();
            }

            return orden;
        }

        [HttpPost]
        public async Task<ActionResult<Orden>> PostOrden(OrdenDTO ordenDTO)
        {
            var orden = new Orden
            {
                EmpleadoId = ordenDTO.EmpleadoId,
                MesaId = ordenDTO.MesaId,
                MontoTotal = ordenDTO.MontoTotal
            };

            _context.Ordenes.Add(orden);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetOrden), new { id = orden.Id }, orden);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrden(int id, OrdenDTO ordenDTO)
        {
            var orden = await _context.Ordenes.FindAsync(id);
            if (orden == null)
            {
                return NotFound();
            }

            orden.EmpleadoId = ordenDTO.EmpleadoId;
            orden.MesaId = ordenDTO.MesaId;
            orden.MontoTotal = ordenDTO.MontoTotal;

            _context.Entry(orden).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrdenExists(id))
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
        public async Task<IActionResult> DeleteOrden(int id)
        {
            var orden = await _context.Ordenes.FindAsync(id);
            if (orden == null)
            {
                return NotFound();
            }

            _context.Ordenes.Remove(orden);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrdenExists(int id)
        {
            return _context.Ordenes.Any(e => e.Id == id);
        }
    }
}
