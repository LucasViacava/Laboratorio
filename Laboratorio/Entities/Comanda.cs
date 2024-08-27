namespace Laboratorio.Entities
{
    public class Comanda
    {

        public int Id { get; set; }
        public int? PedidoId { get; set; }
        public int? MenuItemId { get; set; }
        public int Cantidad { get; set; }
        public string Estado { get; set; } = string.Empty;
        public DateTimeOffset FechaCreacion { get; set; }

        public string Pedido { get; set; } = string.Empty;
        public MenuItem MenuItem { get; set; } = new MenuItem();
    }
}
