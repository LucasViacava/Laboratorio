namespace Laboratorio.DTOs
{
    public class ComandaDTO
    {
        public int Id { get; set; }
        public int? OrdenId { get; set; }
        public int MenuItemId { get; set; }
        public string MenuItemNombre { get; set; }
        public int Cantidad { get; set; }
        public string Estado { get; set; }
        public DateTimeOffset FechaCreacion { get; set; }
    }

}
