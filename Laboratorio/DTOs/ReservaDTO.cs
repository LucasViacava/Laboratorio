namespace Laboratorio.DTOs
{
    public class ReservaDTO
    {
        public string NombreCliente { get; set; }
        public int MesaId { get; set; }
        public DateTimeOffset FechaReserva { get; set; }
    }
}
