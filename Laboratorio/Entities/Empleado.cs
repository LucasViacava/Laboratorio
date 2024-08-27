namespace Laboratorio.Entities
{
    public class Empleado
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Ubicacion { get; set; }
        public DateTime FechaContratacion { get; set; }
        public decimal Salario { get; set; }
        public DateTimeOffset FechaCreacion { get; set; }
        public string? Categoria { get; set; }
        public int? RolId { get; set; }

        public Rol? Rol { get; set; }
    }
}
