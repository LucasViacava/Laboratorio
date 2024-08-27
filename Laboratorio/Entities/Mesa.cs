namespace Laboratorio.Entities
{
    public class Mesa
    {
        public int Id { get; set; }
        public int Numero { get; set; }
        public int Capacidad { get; set; }
        public string? Ubicacion { get; set; }
        public DateTimeOffset FechaCreacion { get; set; }
    }
}
