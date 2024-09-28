using Laboratorio.DTOs;
using Laboratorio.Entities;
using Laboratorio.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class ComandaController : ControllerBase
{
    private readonly ComandaService _comandaService;

    public ComandaController(ComandaService comandaService)
    {
        _comandaService = comandaService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Comanda>>> GetComandas()
    {
        var comandas = await _comandaService.ObtenerComandas();
        return Ok(comandas);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Comanda>> GetComanda(int id)
    {
        var comanda = await _comandaService.ObtenerComandaPorId(id);

        if (comanda == null)
        {
            return NotFound();
        }

        return Ok(comanda);
    }

    [HttpPost]
    public async Task<ActionResult<Comanda>> PostComanda(ComandaDTO comandaDTO)
    {
        var nuevaComanda = await _comandaService.CrearComanda(comandaDTO);
        return CreatedAtAction(nameof(GetComanda), new { id = nuevaComanda.Id }, nuevaComanda);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutComanda(int id, ComandaDTO comandaDTO)
    {
        var actualizado = await _comandaService.ActualizarComanda(id, comandaDTO);

        if (!actualizado)
        {
            return NotFound();
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteComanda(int id)
    {
        var eliminado = await _comandaService.EliminarComanda(id);

        if (!eliminado)
        {
            return NotFound();
        }

        return NoContent();
    }
}
