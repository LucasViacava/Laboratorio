using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Laboratorio.Entities;
using Laboratorio.Data;
namespace Laboratorio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdenItemController : ControllerBase
    {
        private readonly RestauranteContext _context;

        public OrdenItemController(RestauranteContext context)
        {
            _context = context;
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
        public async Task<ActionResult<OrdenItem>> PostOrdenItem(OrdenItem ordenItem)
        {
            _context.OrdenItems.Add(ordenItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetOrdenItem), new { id = ordenItem.Id }, ordenItem);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrdenItem(int id, OrdenItem ordenItem)
        {
            if (id != ordenItem.Id)
            {
                return BadRequest();
            }

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
