using System.ComponentModel.DataAnnotations;

namespace Laboratorio.Entities
{
    public class Reserva
    {
        public Reserva()
        {
            this.FechaCreacion = DateTimeOffset.Now;
        }
        [Key]
        public int Id { get; set; }
        [Required]
        public string NombreCliente { get; set; }
        [Required]
        public int? MesaId { get; set; }
        [Required]
        public DateTimeOffset FechaReserva { get; set; }
        [Required]
        public DateTimeOffset FechaCreacion { get; set; }

        public Mesa? Mesa { get; set; }
    }
}
