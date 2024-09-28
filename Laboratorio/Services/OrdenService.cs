using Laboratorio.Data;
using Laboratorio.DTOs;
using Laboratorio.Entities;
using Microsoft.EntityFrameworkCore;

namespace Laboratorio.Services
{
    public class OrdenService
    {
        private readonly RestauranteContext _context;

        public OrdenService(RestauranteContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Orden>> ObtenerOrdenes()
        {
            return await _context.Ordenes.ToListAsync();
        }

        public async Task<Orden?> ObtenerOrdenPorId(int id)
        {
            return await _context.Ordenes.FindAsync(id);
        }

        public async Task<Orden> CrearOrden(OrdenDTO ordenDTO)
        {
            var orden = new Orden
            {
                EmpleadoId = ordenDTO.EmpleadoId,
                MesaId = ordenDTO.MesaId,
                MontoTotal = ordenDTO.MontoTotal
            };

            _context.Ordenes.Add(orden);
            await _context.SaveChangesAsync();
            return orden;
        }

        public async Task<bool> ActualizarOrden(int id, OrdenDTO ordenDTO)
        {
            var orden = await ObtenerOrdenPorId(id);
            if (orden == null) return false;

            orden.EmpleadoId = ordenDTO.EmpleadoId;
            orden.MesaId = ordenDTO.MesaId;
            orden.MontoTotal = ordenDTO.MontoTotal;

            _context.Entry(orden).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> EliminarOrden(int id)
        {
            var orden = await ObtenerOrdenPorId(id);
            if (orden == null) return false;

            _context.Ordenes.Remove(orden);
            await _context.SaveChangesAsync();
            return true;
        }

        public bool OrdenExiste(int id)
        {
            return _context.Ordenes.Any(e => e.Id == id);
        }
    }
}
