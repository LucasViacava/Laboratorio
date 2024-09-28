using Laboratorio.Data;
using Laboratorio.DTOs;
using Laboratorio.Entities;
using Microsoft.EntityFrameworkCore;

namespace Laboratorio.Services
{
    public class MesaService
    {
        private readonly RestauranteContext _context;

        public MesaService(RestauranteContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Mesa>> ObtenerMesas()
        {
            return await _context.Mesas.ToListAsync();
        }

        public async Task<Mesa?> ObtenerMesaPorId(int id)
        {
            return await _context.Mesas.FindAsync(id);
        }

        public async Task<Mesa> CrearMesa(MesaDTO mesaDTO)
        {
            var mesa = new Mesa
            {
                Numero = mesaDTO.Numero,
                Capacidad = mesaDTO.Capacidad,
                Ubicacion = mesaDTO.Ubicacion
            };

            _context.Mesas.Add(mesa);
            await _context.SaveChangesAsync();
            return mesa;
        }

        public async Task<bool> ActualizarMesa(int id, MesaDTO mesaDTO)
        {
            var mesa = await ObtenerMesaPorId(id);
            if (mesa == null) return false;

            mesa.Numero = mesaDTO.Numero;
            mesa.Capacidad = mesaDTO.Capacidad;
            mesa.Ubicacion = mesaDTO.Ubicacion;

            _context.Entry(mesa).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> EliminarMesa(int id)
        {
            var mesa = await ObtenerMesaPorId(id);
            if (mesa == null) return false;

            _context.Mesas.Remove(mesa);
            await _context.SaveChangesAsync();
            return true;
        }

        public bool MesaExiste(int id)
        {
            return _context.Mesas.Any(e => e.Id == id);
        }
    }
}
