using System.ComponentModel.DataAnnotations;

namespace Laboratorio.Entities
{
    public class Orden
    {
        public Orden() 
        {
            this.FechaCreacion = DateTimeOffset.Now;
            this.Estado = EstadoHelper.GetEstadoAsString(EstadoHelper.EEstado.Pendiente);
            this.Comandas = new List<Comanda>();
            this.OrdenItems = new List<OrdenItem>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        public int EmpleadoId { get; set; }
        public int? MesaId { get; set; }
        //[Required] //Es raro este, porque lo agregamos?
        //public DateTimeOffset FechaOrden { get; set; }
        [Required]
        public string Estado { get; set; }
        [Required]
        public decimal MontoTotal { get; set; }
        [Required]
        public DateTimeOffset FechaCreacion { get; set; }
        public DateTimeOffset? FechaFinalizacion { get; set; }

        public Empleado Empleado { get; set; }
        public Mesa Mesa { get; set; }
        public List<OrdenItem> OrdenItems { get; set; }
        public List<Comanda> Comandas { get; set; }
    }
}
