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
    public class RolController : ControllerBase
    {
        private readonly RestauranteContext _context;

        private readonly IMapper _mapper;

        public RolController(RestauranteContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Rol>>> GetRoles()
        {
            return await _context.Roles.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Rol?>> GetRol(int id)
        {
            var rol = await _context.Roles.FindAsync(id);

            if (rol == null)
            {
                return NotFound();
            }

            return rol;
        }

        [HttpPost]
        public async Task<ActionResult<Rol>> PostRol([FromBody] RolDTO rolDTO)
        {
            var rol = new Rol
            {
                Descripcion = rolDTO.Descripcion
            };
            _context.Roles.Add(rol);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetRol), new { id = rol.Id }, rol);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutRol(int id, RolDTO rolDTO)
        {
            var rol = await _context.Roles.FindAsync(id);
            if (rol == null)
            {
                return NotFound();
            }
            rol.Descripcion = rolDTO.Descripcion;

            _context.Entry(rol).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RolExists(id))
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
        public async Task<IActionResult> DeleteRol(int id)
        {
            var rol = await _context.Roles.FindAsync(id);
            if (rol == null)
            {
                return NotFound();
            }

            _context.Roles.Remove(rol);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RolExists(int id)
        {
            return _context.Roles.Any(e => e.Id == id);
        }
    }
}
