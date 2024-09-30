using System.ComponentModel.DataAnnotations;
using static Laboratorio.Entities.EstadoHelper;

namespace Laboratorio.Entities
{
    public class Orden
    {
        private string _estado;
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
        public string Estado {
            get => _estado;
            set
            {
                if ((_estado == "Finalizado" || _estado == "Cancelado") && _estado != value)
                {
                    throw new Exception("No se puede cambiar el estado una vez que ha sido finalizado o cancelado.");
                }
                _estado = value;
            }
        }
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
