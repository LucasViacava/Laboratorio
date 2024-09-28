using Laboratorio.Data;
using Laboratorio.DTOs;
using Laboratorio.Entities;
using Microsoft.EntityFrameworkCore;

namespace Laboratorio.Services
{
    public class RolService
    {
        private readonly RestauranteContext _context;

        public RolService(RestauranteContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Rol>> ObtenerRoles()
        {
            return await _context.Roles.ToListAsync();
        }

        public async Task<Rol?> ObtenerRolPorId(int id)
        {
            return await _context.Roles.FindAsync(id);
        }

        public async Task<Rol> CrearRol(RolDTO rolDTO)
        {
            var rol = new Rol
            {
                Descripcion = rolDTO.Descripcion
            };

            _context.Roles.Add(rol);
            await _context.SaveChangesAsync();
            return rol;
        }

        public async Task<bool> ActualizarRol(int id, RolDTO rolDTO)
        {
            var rol = await ObtenerRolPorId(id);
            if (rol == null) return false;

            rol.Descripcion = rolDTO.Descripcion;

            _context.Entry(rol).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> EliminarRol(int id)
        {
            var rol = await ObtenerRolPorId(id);
            if (rol == null) return false;

            _context.Roles.Remove(rol);
            await _context.SaveChangesAsync();
            return true;
        }

        public bool RolExiste(int id)
        {
            return _context.Roles.Any(e => e.Id == id);
        }
    }
}
