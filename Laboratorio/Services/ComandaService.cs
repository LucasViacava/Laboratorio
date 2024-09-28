using Laboratorio.Data;
using Laboratorio.DTOs;
using Laboratorio.Entities;
using Microsoft.EntityFrameworkCore;

namespace Laboratorio.Services
{
    public class ComandaService
    {
        private readonly RestauranteContext _context;

        public ComandaService(RestauranteContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Comanda>> ObtenerComandas()
        {
            return await _context.Comandas.ToListAsync();
        }

        public async Task<Comanda?> ObtenerComandaPorId(int id)
        {
            return await _context.Comandas.FindAsync(id);
        }

        public async Task<Comanda> CrearComanda(ComandaDTO comandaDTO)
        {
            var comanda = new Comanda
            {
                PedidoId = comandaDTO.PedidoId,
                MenuItemId = comandaDTO.MenuItemId,
                Cantidad = comandaDTO.Cantidad
            };

            _context.Comandas.Add(comanda);
            await _context.SaveChangesAsync();
            return comanda;
        }

        public async Task<bool> ActualizarComanda(int id, ComandaDTO comandaDTO)
        {
            var comanda = await ObtenerComandaPorId(id);
            if (comanda == null) return false;

            comanda.PedidoId = comandaDTO.PedidoId;
            comanda.MenuItemId = comandaDTO.MenuItemId;
            comanda.Cantidad = comandaDTO.Cantidad;

            _context.Entry(comanda).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> EliminarComanda(int id)
        {
            var comanda = await ObtenerComandaPorId(id);
            if (comanda == null) return false;

            _context.Comandas.Remove(comanda);
            await _context.SaveChangesAsync();
            return true;
        }

        public bool ComandaExiste(int id)
        {
            return _context.Comandas.Any(e => e.Id == id);
        }
    }
}
