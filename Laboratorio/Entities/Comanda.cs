using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Laboratorio.Entities.EstadoHelper;

namespace Laboratorio.Entities
{
    public class Comanda
    {
        private string _estado;
        public Comanda()
        {
            this.FechaCreacion = DateTimeOffset.Now;
            this.Estado = EstadoHelper.GetEstadoAsString(EstadoHelper.EEstado.Pendiente);
        }
        [Key]
        public int Id { get; set; }
        [Required]
        public int OrdenId { get; set; }
        [Required]
        public int MenuItemId { get; set; }
        [Required]
        public int Cantidad { get; set; }
        public string Estado
        {
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
        public DateTimeOffset FechaCreacion { get; set; }
        public Orden Orden { get; set; }
        public MenuItem MenuItem { get; set; }
    }
}
