namespace Laboratorio.DTOs
{
    public class PagoDTO
    {
        public int OrdenId { get; set; }
        public decimal Monto { get; set; }
        public string Metodo { get; set; }
        public DateTimeOffset FechaPago { get; set; }
    }
}
