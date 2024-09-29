namespace Laboratorio.DTOs
{
    public class OrdenInfoDTO
    {
        public int OrdenId { get; set; }
        public int? MesaId { get; set; }
        public string EmpleadoNombre { get; set; }
        public string Estado { get; set; }
        public DateTimeOffset FechaCreacion { get; set; }
        public DateTimeOffset? FechaFinalizacion { get; set; }
        public int TiempoTotalPreparacion { get; set; }
    }

}
