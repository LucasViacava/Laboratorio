namespace Laboratorio.Entities
{
    public class Pago
    {
        public int Id { get; set; }
        public int? OrdenId { get; set; }
        public decimal Monto { get; set; }
        public string Metodo { get; set; } = string.Empty;
        public DateTimeOffset FechaPago { get; set; }
        public DateTimeOffset FechaCreacion { get; set; }

        public Orden? Orden { get; set; }
    }
}
