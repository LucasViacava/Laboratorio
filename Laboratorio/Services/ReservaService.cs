using Laboratorio.Data;
using Laboratorio.DTOs;
using Laboratorio.Entities;
using Microsoft.EntityFrameworkCore;

namespace Laboratorio.Services
{
    public class ReservaService
    {
        private readonly RestauranteContext _context;

        public ReservaService(RestauranteContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Reserva>> ObtenerReservas()
        {
            return await _context.Reservas.ToListAsync();
        }

        public async Task<Reserva?> ObtenerReservaPorId(int id)
        {
            return await _context.Reservas.FindAsync(id);
        }

        public async Task<Reserva> CrearReserva(ReservaDTO reservaDTO)
        {
            var reserva = new Reserva
            {
                NombreCliente = reservaDTO.NombreCliente,
                MesaId = reservaDTO.MesaId,
                FechaReserva = reservaDTO.FechaReserva
            };

            _context.Reservas.Add(reserva);
            await _context.SaveChangesAsync();
            return reserva;
        }

        public async Task<bool> ActualizarReserva(int id, ReservaDTO reservaDTO)
        {
            var reserva = await ObtenerReservaPorId(id);
            if (reserva == null) return false;

            reserva.NombreCliente = reservaDTO.NombreCliente;
            reserva.MesaId = reservaDTO.MesaId;
            reserva.FechaReserva = reservaDTO.FechaReserva;

            _context.Entry(reserva).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> EliminarReserva(int id)
        {
            var reserva = await ObtenerReservaPorId(id);
            if (reserva == null) return false;

            _context.Reservas.Remove(reserva);
            await _context.SaveChangesAsync();
            return true;
        }

        public bool ReservaExiste(int id)
        {
            return _context.Reservas.Any(e => e.Id == id);
        }
    }
}
