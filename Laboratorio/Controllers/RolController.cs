using Laboratorio.DTOs;
using Laboratorio.Entities;
using Laboratorio.Services;
using Microsoft.AspNetCore.Mvc;

namespace Laboratorio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolController : ControllerBase
    {
        private readonly RolService _rolService;

        public RolController(RolService rolService)
        {
            _rolService = rolService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Rol>>> GetRoles()
        {
            var roles = await _rolService.ObtenerRoles();
            return Ok(roles);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Rol?>> GetRol(int id)
        {
            var rol = await _rolService.ObtenerRolPorId(id);

            if (rol == null)
            {
                return NotFound();
            }

            return Ok(rol);
        }

        [HttpPost]
        public async Task<ActionResult<Rol>> PostRol([FromBody] RolDTO rolDTO)
        {
            var nuevoRol = await _rolService.CrearRol(rolDTO);
            return CreatedAtAction(nameof(GetRol), new { id = nuevoRol.Id }, nuevoRol);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutRol(int id, RolDTO rolDTO)
        {
            var actualizado = await _rolService.ActualizarRol(id, rolDTO);

            if (!actualizado)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRol(int id)
        {
            var eliminado = await _rolService.EliminarRol(id);

            if (!eliminado)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
