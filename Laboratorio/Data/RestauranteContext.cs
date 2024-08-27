using Microsoft.EntityFrameworkCore;
using Laboratorio.Entities;

namespace Laboratorio.Data
{
    public class RestauranteContext : DbContext
    {
        public RestauranteContext(DbContextOptions<RestauranteContext> options) : base(options)
        {
        }

        public RestauranteContext(DbSet<Comanda> comandas, DbSet<Empleado> empleados, DbSet<MenuItem> menuItems, DbSet<Mesa> mesas, DbSet<Orden> ordenes, DbSet<OrdenItem> ordenItems, DbSet<Pago> pagos, DbSet<Reserva> reservas, DbSet<Rol> roles)
        {
            Comandas = comandas;
            Empleados = empleados;
            MenuItems = menuItems;
            Mesas = mesas;
            Ordenes = ordenes;
            OrdenItems = ordenItems;
            Pagos = pagos;
            Reservas = reservas;
            Roles = roles;
        }

        public DbSet<Comanda> Comandas { get; set; } 
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; } 
        public DbSet<Mesa> Mesas { get; set; } 
        public DbSet<Orden> Ordenes { get; set; }
        public DbSet<OrdenItem> OrdenItems { get; set; }
        public DbSet<Pago> Pagos { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<Rol> Roles { get; set; } 
    }
}
