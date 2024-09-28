using Laboratorio.Data;
using Laboratorio.DTOs;
using Laboratorio.Entities;
using Microsoft.EntityFrameworkCore;

namespace Laboratorio.Services
{
    public class EmpleadoService
    {
        private readonly RestauranteContext _context;

        public EmpleadoService(RestauranteContext context)
        {
            _context = context;
        }
        public async Task<Empleado> CrearEmpleado(EmpleadoDTO empleadoDto)
        {
            var empleado = new Empleado
            {
                Nombre = empleadoDto.Nombre,
                Ubicacion = empleadoDto.Ubicacion,
                FechaContratacion = empleadoDto.FechaContratacion,
                Salario = empleadoDto.Salario,
                Categoria = empleadoDto.Categoria,
                RolId = empleadoDto.RolId
            };

            _context.Empleados.Add(empleado);
            await _context.SaveChangesAsync();
            return empleado;
        }
        public async Task<IEnumerable<Empleado>> ObtenerEmpleados()
        {
            return await _context.Empleados.ToListAsync();
        }
        public async Task<Empleado?> ObtenerEmpleadoPorId(int id)
        {
            return await _context.Empleados.FirstOrDefaultAsync(e => e.Id == id);
        }
        public async Task<bool> ActualizarEmpleado(int id, EmpleadoDTO empleadoDto)
        {
            var empleado = await ObtenerEmpleadoPorId(id);
            if (empleado == null) return false;

            empleado.Nombre = empleadoDto.Nombre;
            empleado.Ubicacion = empleadoDto.Ubicacion;
            empleado.FechaContratacion = empleadoDto.FechaContratacion;
            empleado.Salario = empleadoDto.Salario;
            empleado.Categoria = empleadoDto.Categoria;
            empleado.RolId = empleadoDto.RolId;

            _context.Empleados.Update(empleado);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> EliminarEmpleado(int id)
        {
            var empleado = await ObtenerEmpleadoPorId(id);
            if (empleado == null) return false;

            _context.Empleados.Remove(empleado);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
