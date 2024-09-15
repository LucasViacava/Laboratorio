using System.ComponentModel.DataAnnotations;

namespace Laboratorio.Entities
{
    public class OrdenItem
    {
        public OrdenItem()
        {
            this.FechaCreacion = DateTimeOffset.Now;
        }

        [Key]
        public int Id { get; set; }
        [Required]
        public int OrdenId { get; set; }
        [Required]
        public int MenuItemId { get; set; }
        [Required]
        public int Cantidad { get; set; }
        [Required]
        public decimal Precio { get; set; }
        [Required]
        public DateTimeOffset FechaCreacion { get; set; }

        public Orden? Orden { get; set; }
        public MenuItem? MenuItem { get; set; }
    }
}
