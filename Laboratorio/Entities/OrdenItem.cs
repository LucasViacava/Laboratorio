namespace Laboratorio.Entities
{
    public class OrdenItem
    {
        public int Id { get; set; }
        public int? OrdenId { get; set; }
        public int? MenuItemId { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public DateTimeOffset FechaCreacion { get; set; }

        public Orden? Orden { get; set; }
        public MenuItem? MenuItem { get; set; }
    }
}
