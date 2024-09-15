using System.ComponentModel.DataAnnotations;

namespace Laboratorio.Entities
{
    public class Pago
    {
        public Pago()
        {
            this.FechaCreacion = DateTimeOffset.Now;
        }
        [Key]
        public int Id { get; set; } 
        [Required]
        public int OrdenId { get; set; }
        [Required]
        public decimal Monto { get; set; }
        [Required]
        public string Metodo { get; set; } = string.Empty;
        public DateTimeOffset FechaPago { get; set; }
        [Required]
        public DateTimeOffset FechaCreacion { get; set; }

        public Orden? Orden { get; set; }
    }
}
