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
    public class OrdenItemController : ControllerBase
    {
        private readonly RestauranteContext _context;

        private readonly IMapper _mapper;

        public OrdenItemController(RestauranteContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrdenItem>>> GetOrdenItems()
        {
            return await _context.OrdenItems.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrdenItem?>> GetOrdenItem(int id)
        {
            var ordenItem = await _context.OrdenItems.FindAsync(id);

            if (ordenItem == null)
            {
                return NotFound();
            }

            return ordenItem;
        }

        [HttpPost]
        public async Task<ActionResult<OrdenItem>> PostOrdenItem(OrdenItemDTO ordenItemDTO)
        {
            var ordenItem = new OrdenItem
            {
                OrdenId = ordenItemDTO.OrdenId,
                MenuItemId = ordenItemDTO.MenuItemId,
                Cantidad = ordenItemDTO.Cantidad,
                Precio = ordenItemDTO.Precio
            };

            _context.OrdenItems.Add(ordenItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetOrdenItem), new { id = ordenItem.Id }, ordenItem);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrdenItem(int id, OrdenItemDTO ordenItemDTO)
        {
            var ordenItem = await _context.OrdenItems.FindAsync(id);
            if (ordenItem == null)
            {
                return NotFound();
            }

            ordenItem.OrdenId = ordenItemDTO.OrdenId;
            ordenItem.MenuItemId = ordenItemDTO.MenuItemId;
            ordenItem.Cantidad = ordenItemDTO.Cantidad;
            ordenItem.Precio = ordenItemDTO.Precio;

            _context.Entry(ordenItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrdenItemExists(id))
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
        public async Task<IActionResult> DeleteOrdenItem(int id)
        {
            var ordenItem = await _context.OrdenItems.FindAsync(id);
            if (ordenItem == null)
            {
                return NotFound();
            }

            _context.OrdenItems.Remove(ordenItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrdenItemExists(int id)
        {
            return _context.OrdenItems.Any(e => e.Id == id);
        }
    }
}
