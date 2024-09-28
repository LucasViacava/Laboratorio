using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Laboratorio.Entities
{
    public class Comanda
    {
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
        public string Estado { get; set; } = string.Empty;
        public DateTimeOffset FechaCreacion { get; set; }
        public Orden Orden { get; set; }
        public MenuItem MenuItem { get; set; }
    }
}
