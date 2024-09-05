using Microsoft.EntityFrameworkCore;
using Laboratorio.Entities;

namespace Laboratorio.Data
{
    public class RestauranteContext : DbContext
    {
        public RestauranteContext(DbContextOptions<RestauranteContext> options) : base(options)
        {
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seeding MenuItem data
            modelBuilder.Entity<MenuItem>().HasData(
                new MenuItem { Id = 1, Nombre = "Milanesa a Caballo", Precio = 800m },
                new MenuItem { Id = 2, Nombre = "Hamburguesa de Garbanzo", Precio = 500m },
                new MenuItem { Id = 3, Nombre = "Corona", Precio = 200m },
                new MenuItem { Id = 4, Nombre = "Daikiri", Precio = 300m }
            );

            // Configurar el tipo de la columna 'Monto' de la entidad 'Pago'
            modelBuilder.Entity<Pago>()
                .Property(p => p.Monto)
                .HasColumnType("decimal(18,2)");

            // Configurar el tipo de la columna 'Precio' de la entidad 'OrdenItem'
            modelBuilder.Entity<OrdenItem>()
                .Property(oi => oi.Precio)
                .HasColumnType("decimal(18,2)");

            // Configurar el tipo de la columna 'MontoTotal' de la entidad 'Orden'
            modelBuilder.Entity<Orden>()
                .Property(o => o.MontoTotal)
                .HasColumnType("decimal(18,2)");

            // Seeding Comanda data
            modelBuilder.Entity<Comanda>().HasData(
                new Comanda
                {
                    Id = 1,
                    PedidoId = 1,
                    MenuItemId = 1,  // Relación con MenuItem usando la clave foránea
                    Cantidad = 1,
                    Estado = "En Preparación",
                    FechaCreacion = DateTimeOffset.Now
                },
                new Comanda
                {
                    Id = 2,
                    PedidoId = 1,
                    MenuItemId = 2,
                    Cantidad = 2,
                    Estado = "En Preparación",
                    FechaCreacion = DateTimeOffset.Now
                },
                new Comanda
                {
                    Id = 3,
                    PedidoId = 1,
                    MenuItemId = 3,
                    Cantidad = 1,
                    Estado = "En Preparación",
                    FechaCreacion = DateTimeOffset.Now
                },
                new Comanda
                {
                    Id = 4,
                    PedidoId = 1,
                    MenuItemId = 4,
                    Cantidad = 1,
                    Estado = "En Preparación",
                    FechaCreacion = DateTimeOffset.Now
                }
            );
        }
    }
}
