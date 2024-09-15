using System.ComponentModel.DataAnnotations;

namespace Laboratorio.Entities
{
    public class Rol
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Descripcion { get; set; }
    }
}
