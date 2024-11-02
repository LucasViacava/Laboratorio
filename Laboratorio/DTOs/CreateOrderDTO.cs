namespace Laboratorio.DTOs
{
    public class CreateOrderDTO
    {
        public List<MenuItemRequestDTO> MenuItems { get; set; }
        public int Mesa { get; set; }
    }

    public class MenuItemRequestDTO
    {
        public string Plato { get; set; }
        public int Cantidad { get; set; }
    }
}
