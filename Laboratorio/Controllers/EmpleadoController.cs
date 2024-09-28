using Laboratorio.DTOs;
using Laboratorio.Entities;
using Laboratorio.Services;
using Microsoft.AspNetCore.Mvc;

namespace Laboratorio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        private readonly EmpleadoService _empleadoService;

        public EmpleadoController(EmpleadoService empleadoService)
        {
            _empleadoService = empleadoService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Empleado>>> GetEmpleados()
        {
            var empleados = await _empleadoService.ObtenerEmpleados();
            return Ok(empleados);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Empleado>> GetEmpleado(int id)
        {
            var empleado = await _empleadoService.ObtenerEmpleadoPorId(id);

            if (empleado == null)
            {
                return NotFound();
            }

            return Ok(empleado);
        }
        [HttpPost]
        public async Task<ActionResult<Empleado>> PostEmpleado([FromBody] EmpleadoDTO empleadoDto)
        {
            var nuevoEmpleado = await _empleadoService.CrearEmpleado(empleadoDto);
            return CreatedAtAction(nameof(GetEmpleado), new { id = nuevoEmpleado.Id }, nuevoEmpleado);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmpleado(int id, [FromBody] EmpleadoDTO empleadoDto)
        {
            var actualizado = await _empleadoService.ActualizarEmpleado(id, empleadoDto);

            if (!actualizado)
            {
                return NotFound();
            }

            return Ok("Actualizado con éxito.");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmpleado(int id)
        {
            var eliminado = await _empleadoService.EliminarEmpleado(id);

            if (!eliminado)
            {
                return NotFound();
            }

            return Ok("Eliminado con éxito.");
        }
    }
}
