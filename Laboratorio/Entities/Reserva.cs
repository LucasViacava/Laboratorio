namespace Laboratorio.Entities
{
    public class Reserva
    {
        public int Id { get; set; }
        public int? MesaId { get; set; }
        public DateTimeOffset FechaReserva { get; set; }
        public DateTimeOffset FechaCreacion { get; set; }

        public Mesa? Mesa { get; set; }
    }
}
