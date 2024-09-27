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
    public class EmpleadoController : ControllerBase
    {
        private readonly RestauranteContext _context;
        private readonly IMapper _mapper;

        public EmpleadoController(RestauranteContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;        
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Empleado>>> GetEmpleados()
        {
            return await _context.Empleados.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Empleado?>> GetEmpleado(int id)
        {
            var empleado = await _context.Empleados.FindAsync(id);

            if (empleado == null)
            {
                return NotFound();
            }

            return empleado;
        }

        [HttpPost]
        public async Task<ActionResult<Empleado>> PostEmpleado(EmpleadoDTO empleadoDTO)
        {
            var empleado = new Empleado
            {
                Nombre = empleadoDTO.Nombre,
                Ubicacion = empleadoDTO.Ubicacion,
                FechaContratacion = empleadoDTO.FechaContratacion,
                Salario = empleadoDTO.Salario,
                Categoria = empleadoDTO.Categoria,
                RolId = empleadoDTO.RolId
            };

            _context.Empleados.Add(empleado);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEmpleado), new { id = empleado.Id }, empleado);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmpleado(int id, EmpleadoDTO empleadoDTO)
        {
            var empleado = await _context.Empleados.FindAsync(id);
            if (empleado == null)
            {
                return NotFound();
            }

            empleado.Nombre = empleadoDTO.Nombre;
            empleado.Ubicacion = empleadoDTO.Ubicacion;
            empleado.FechaContratacion = empleadoDTO.FechaContratacion;
            empleado.Salario = empleadoDTO.Salario;
            empleado.Categoria = empleadoDTO.Categoria;
            empleado.RolId = empleadoDTO.RolId;

            _context.Entry(empleado).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpleadoExists(id))
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
        public async Task<IActionResult> DeleteEmpleado(int id)
        {
            var empleado = await _context.Empleados.FindAsync(id);
            if (empleado == null)
            {
                return NotFound();
            }

            _context.Empleados.Remove(empleado);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmpleadoExists(int id)
        {
            return _context.Empleados.Any(e => e.Id == id);
        }
    }
}
