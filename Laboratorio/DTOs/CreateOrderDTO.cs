namespace Laboratorio.DTOs
{
    public class CreateOrderDTO
    {
        public string CreatedBy { get; set; }
        public List<MenuItemRequestDTO> MenuItems { get; set; }
        public int Mesa { get; set; }
    }

    public class MenuItemRequestDTO
    {
        public string Plato { get; set; }
        public int Cantidad { get; set; }
    }
}
