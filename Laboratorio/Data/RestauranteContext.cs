using Microsoft.EntityFrameworkCore;
using Laboratorio.Entities;

namespace Laboratorio.Data
{
    public class RestauranteContext : DbContext
    {
        public RestauranteContext(DbContextOptions<RestauranteContext> options) : base(options) { }

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
            base.OnModelCreating(modelBuilder);

            // Seed Data para Roles (5 roles diferentes)
            modelBuilder.Entity<Rol>().HasData(
                new Rol { Id = 1, Descripcion = "Mozo" },
                new Rol { Id = 2, Descripcion = "Chef" },
                new Rol { Id = 3, Descripcion = "Bartender" },
                new Rol { Id = 4, Descripcion = "Cajero" },
                new Rol { Id = 5, Descripcion = "Gerente" }
            );

            // Seed Data para Empleados (5 empleados con diferentes roles)
            modelBuilder.Entity<Empleado>().HasData(
                new Empleado { Id = 1, Nombre = "Juan Perez", Ubicacion = "Interior", UserName = "jperez", Password = "1234", FechaContratacion = DateTime.Now, Salario = 2000, RolId = 1 },
                new Empleado { Id = 2, Nombre = "Maria Garcia", Ubicacion = "Cocina", UserName = "mgarcia", Password = "1234", FechaContratacion = DateTime.Now, Salario = 2500, RolId = 2 },
                new Empleado { Id = 3, Nombre = "Carlos Sanchez", Ubicacion = "Bar", UserName = "csanchez", Password = "1234", FechaContratacion = DateTime.Now, Salario = 2200, RolId = 3 },
                new Empleado { Id = 4, Nombre = "Ana Lopez", Ubicacion = "Caja", UserName = "alopez", Password = "1234", FechaContratacion = DateTime.Now, Salario = 2300, RolId = 4 },
                new Empleado { Id = 5, Nombre = "Roberto Diaz", Ubicacion = "Oficina", UserName = "rdiaz", Password = "1234", FechaContratacion = DateTime.Now, Salario = 3000, RolId = 5 }
            );

            // Seed Data para Mesas (10 mesas)
            modelBuilder.Entity<Mesa>().HasData(
                new Mesa { Id = 1, Numero = 101, Capacidad = 4, Ubicacion = "Interior" },
                new Mesa { Id = 2, Numero = 102, Capacidad = 2, Ubicacion = "Terraza" },
                new Mesa { Id = 3, Numero = 103, Capacidad = 6, Ubicacion = "Interior" },
                new Mesa { Id = 4, Numero = 104, Capacidad = 4, Ubicacion = "Patio" },
                new Mesa { Id = 5, Numero = 105, Capacidad = 8, Ubicacion = "Terraza" },
                new Mesa { Id = 6, Numero = 106, Capacidad = 2, Ubicacion = "Interior" },
                new Mesa { Id = 7, Numero = 107, Capacidad = 6, Ubicacion = "Terraza" },
                new Mesa { Id = 8, Numero = 108, Capacidad = 4, Ubicacion = "Interior" },
                new Mesa { Id = 9, Numero = 109, Capacidad = 2, Ubicacion = "Interior" },
                new Mesa { Id = 10, Numero = 110, Capacidad = 6, Ubicacion = "Terraza" }
            );

            // Seed Data para MenuItems (10 platillos y bebidas)
            modelBuilder.Entity<MenuItem>().HasData(
                new MenuItem { Id = 1, Nombre = "Milanesa a Caballo", Precio = 800m, Categoria = "Principal", TiempoPreparacion = 15 },
                new MenuItem { Id = 2, Nombre = "Hamburguesa de Garbanzo", Precio = 500m, Categoria = "Vegetariano", TiempoPreparacion = 10 },
                new MenuItem { Id = 3, Nombre = "Ensalada Caesar", Precio = 700m, Categoria = "Entrada", TiempoPreparacion = 5 },
                new MenuItem { Id = 4, Nombre = "Pizza Margherita", Precio = 900m, Categoria = "Principal", TiempoPreparacion = 20 },
                new MenuItem { Id = 5, Nombre = "Spaghetti a la Bolognesa", Precio = 850m, Categoria = "Principal", TiempoPreparacion = 18 },
                new MenuItem { Id = 6, Nombre = "Tacos al Pastor", Precio = 600m, Categoria = "Principal", TiempoPreparacion = 12 },
                new MenuItem { Id = 7, Nombre = "Corona", Precio = 200m, Categoria = "Bebida", TiempoPreparacion = 1 },
                new MenuItem { Id = 8, Nombre = "Daikiri", Precio = 300m, Categoria = "Bebida", TiempoPreparacion = 7 },
                new MenuItem { Id = 9, Nombre = "Limonada", Precio = 150m, Categoria = "Bebida", TiempoPreparacion = 2 },
                new MenuItem { Id = 10, Nombre = "Brownie con Helado", Precio = 400m, Categoria = "Postre", TiempoPreparacion = 9 }
            );
        }
    }
}
