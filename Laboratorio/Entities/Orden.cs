namespace Laboratorio.Entities
{
    public class Orden
    {
        public int Id { get; set; }
        public int? EmpleadoId { get; set; }
        public int? MesaId { get; set; }
        public DateTimeOffset FechaOrden { get; set; }
        public string? Estado { get; set; }
        public decimal MontoTotal { get; set; }
        public DateTimeOffset FechaCreacion { get; set; }

        public Empleado? Empleado { get; set; }
        public Mesa? Mesa { get; set; }
    }
}
