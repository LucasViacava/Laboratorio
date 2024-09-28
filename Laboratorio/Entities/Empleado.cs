using System.ComponentModel.DataAnnotations;

namespace Laboratorio.Entities
{
    public class Empleado
    {
        public Empleado()
        {
            this.FechaCreacion = DateTimeOffset.Now;
        }
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Ubicacion { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required] 
        public string Password { get; set; }
        [Required]
        public DateTime FechaContratacion { get; set; }
        [Required]
        public decimal Salario { get; set; }
        public DateTimeOffset FechaCreacion { get; set; }
        public string? Categoria { get; set; }
        [Required]
        public int? RolId { get; set; }

        public Rol? Rol { get; set; }
    }
}
