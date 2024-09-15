using System.ComponentModel.DataAnnotations;

namespace Laboratorio.Entities
{
    public class Mesa
    {
        public Mesa()
        {
            this.FechaCreacion = DateTimeOffset.Now;
        }
        [Key]
        public int Id { get; set; }
        [Required]
        public int Numero { get; set; }
        [Required]
        public int Capacidad { get; set; }
        [Required]
        public string Ubicacion { get; set; }
        public DateTimeOffset FechaCreacion { get; set; }
    }
}
