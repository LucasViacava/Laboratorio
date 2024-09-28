using Laboratorio.Data;
using Laboratorio.DTOs;
using Laboratorio.Entities;
using Microsoft.EntityFrameworkCore;

namespace Laboratorio.Services
{
    public class PagoService
    {
        private readonly RestauranteContext _context;

        public PagoService(RestauranteContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Pago>> ObtenerPagos()
        {
            return await _context.Pagos.ToListAsync();
        }

        public async Task<Pago?> ObtenerPagoPorId(int id)
        {
            return await _context.Pagos.FindAsync(id);
        }

        public async Task<Pago> CrearPago(PagoDTO pagoDTO)
        {
            var pago = new Pago
            {
                OrdenId = pagoDTO.OrdenId,
                Monto = pagoDTO.Monto,
                Metodo = pagoDTO.Metodo,
                FechaPago = pagoDTO.FechaPago
            };

            _context.Pagos.Add(pago);
            await _context.SaveChangesAsync();
            return pago;
        }

        public async Task<bool> ActualizarPago(int id, PagoDTO pagoDTO)
        {
            var pago = await ObtenerPagoPorId(id);
            if (pago == null) return false;

            pago.OrdenId = pagoDTO.OrdenId;
            pago.Monto = pagoDTO.Monto;
            pago.Metodo = pagoDTO.Metodo;
            pago.FechaPago = pagoDTO.FechaPago;

            _context.Entry(pago).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> EliminarPago(int id)
        {
            var pago = await ObtenerPagoPorId(id);
            if (pago == null) return false;

            _context.Pagos.Remove(pago);
            await _context.SaveChangesAsync();
            return true;
        }

        public bool PagoExiste(int id)
        {
            return _context.Pagos.Any(e => e.Id == id);
        }
    }
}
