using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Laboratorio.Entities;
using Laboratorio.Data;

[Route("api/[controller]")]
[ApiController]
public class ComandaController : ControllerBase
{
    private readonly RestauranteContext _context;

    public ComandaController(RestauranteContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Comanda>>> GetComandas()
    {
        return await _context.Comandas.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Comanda>> GetComanda(int id)
    {
        var comanda = await _context.Comandas.FindAsync(id);

        if (comanda == null)
        {
            return NotFound();
        }

        return comanda;
    }

    [HttpPost]
    public async Task<ActionResult<Comanda>> PostComanda(Comanda comanda)
    {
        _context.Comandas.Add(comanda);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetComanda), new { id = comanda.Id }, comanda);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutComanda(int id, Comanda comanda)
    {
        if (id != comanda.Id)
        {
            return BadRequest();
        }

        _context.Entry(comanda).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ComandaExists(id))
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
    public async Task<IActionResult> DeleteComanda(int id)
    {
        var comanda = await _context.Comandas.FindAsync(id);
        if (comanda == null)
        {
            return NotFound();
        }

        _context.Comandas.Remove(comanda);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool ComandaExists(int id)
    {
        return _context.Comandas.Any(e => e.Id == id);
    }
}
