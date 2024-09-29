using System.ComponentModel.DataAnnotations;

namespace Laboratorio.Entities
{
    public class MenuItem
    {
        public MenuItem() 
        { 
            this.FechaCreacion = DateTimeOffset.Now;
        }
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        public string? Descripcion { get; set; }
        [Required]
        public decimal Precio { get; set; }
        public string? Categoria { get; set; }
        public DateTimeOffset FechaCreacion { get; set; }
        public int TiempoPreparacion { get; set; }
    }
}
