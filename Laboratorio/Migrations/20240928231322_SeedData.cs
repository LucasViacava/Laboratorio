using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Laboratorio.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MenuItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Categoria = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaCreacion = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mesas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    Capacidad = table.Column<int>(type: "int", nullable: false),
                    Ubicacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaCreacion = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mesas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reservas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreCliente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MesaId = table.Column<int>(type: "int", nullable: false),
                    FechaReserva = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    FechaCreacion = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservas_Mesas_MesaId",
                        column: x => x.MesaId,
                        principalTable: "Mesas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Empleados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ubicacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaContratacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Salario = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FechaCreacion = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Categoria = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RolId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Empleados_Roles_RolId",
                        column: x => x.RolId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ordenes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpleadoId = table.Column<int>(type: "int", nullable: false),
                    MesaId = table.Column<int>(type: "int", nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MontoTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FechaCreacion = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ordenes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ordenes_Empleados_EmpleadoId",
                        column: x => x.EmpleadoId,
                        principalTable: "Empleados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ordenes_Mesas_MesaId",
                        column: x => x.MesaId,
                        principalTable: "Mesas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Comandas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrdenId = table.Column<int>(type: "int", nullable: false),
                    MenuItemId = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaCreacion = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comandas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comandas_MenuItems_MenuItemId",
                        column: x => x.MenuItemId,
                        principalTable: "MenuItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comandas_Ordenes_OrdenId",
                        column: x => x.OrdenId,
                        principalTable: "Ordenes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrdenItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrdenId = table.Column<int>(type: "int", nullable: false),
                    MenuItemId = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FechaCreacion = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdenItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrdenItems_MenuItems_MenuItemId",
                        column: x => x.MenuItemId,
                        principalTable: "MenuItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrdenItems_Ordenes_OrdenId",
                        column: x => x.OrdenId,
                        principalTable: "Ordenes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pagos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrdenId = table.Column<int>(type: "int", nullable: false),
                    Monto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Metodo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaPago = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    FechaCreacion = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pagos_Ordenes_OrdenId",
                        column: x => x.OrdenId,
                        principalTable: "Ordenes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "MenuItems",
                columns: new[] { "Id", "Categoria", "Descripcion", "FechaCreacion", "Nombre", "Precio" },
                values: new object[,]
                {
                    { 1, "Principal", null, new DateTimeOffset(new DateTime(2024, 9, 28, 20, 13, 22, 584, DateTimeKind.Unspecified).AddTicks(302), new TimeSpan(0, -3, 0, 0, 0)), "Milanesa a Caballo", 800m },
                    { 2, "Vegetariano", null, new DateTimeOffset(new DateTime(2024, 9, 28, 20, 13, 22, 584, DateTimeKind.Unspecified).AddTicks(304), new TimeSpan(0, -3, 0, 0, 0)), "Hamburguesa de Garbanzo", 500m },
                    { 3, "Entrada", null, new DateTimeOffset(new DateTime(2024, 9, 28, 20, 13, 22, 584, DateTimeKind.Unspecified).AddTicks(305), new TimeSpan(0, -3, 0, 0, 0)), "Ensalada Caesar", 700m },
                    { 4, "Principal", null, new DateTimeOffset(new DateTime(2024, 9, 28, 20, 13, 22, 584, DateTimeKind.Unspecified).AddTicks(306), new TimeSpan(0, -3, 0, 0, 0)), "Pizza Margherita", 900m },
                    { 5, "Principal", null, new DateTimeOffset(new DateTime(2024, 9, 28, 20, 13, 22, 584, DateTimeKind.Unspecified).AddTicks(307), new TimeSpan(0, -3, 0, 0, 0)), "Spaghetti a la Bolognesa", 850m },
                    { 6, "Principal", null, new DateTimeOffset(new DateTime(2024, 9, 28, 20, 13, 22, 584, DateTimeKind.Unspecified).AddTicks(308), new TimeSpan(0, -3, 0, 0, 0)), "Tacos al Pastor", 600m },
                    { 7, "Bebida", null, new DateTimeOffset(new DateTime(2024, 9, 28, 20, 13, 22, 584, DateTimeKind.Unspecified).AddTicks(308), new TimeSpan(0, -3, 0, 0, 0)), "Corona", 200m },
                    { 8, "Bebida", null, new DateTimeOffset(new DateTime(2024, 9, 28, 20, 13, 22, 584, DateTimeKind.Unspecified).AddTicks(309), new TimeSpan(0, -3, 0, 0, 0)), "Daikiri", 300m },
                    { 9, "Bebida", null, new DateTimeOffset(new DateTime(2024, 9, 28, 20, 13, 22, 584, DateTimeKind.Unspecified).AddTicks(310), new TimeSpan(0, -3, 0, 0, 0)), "Limonada", 150m },
                    { 10, "Postre", null, new DateTimeOffset(new DateTime(2024, 9, 28, 20, 13, 22, 584, DateTimeKind.Unspecified).AddTicks(311), new TimeSpan(0, -3, 0, 0, 0)), "Brownie con Helado", 400m }
                });

            migrationBuilder.InsertData(
                table: "Mesas",
                columns: new[] { "Id", "Capacidad", "FechaCreacion", "Numero", "Ubicacion" },
                values: new object[,]
                {
                    { 1, 4, new DateTimeOffset(new DateTime(2024, 9, 28, 20, 13, 22, 584, DateTimeKind.Unspecified).AddTicks(283), new TimeSpan(0, -3, 0, 0, 0)), 101, "Interior" },
                    { 2, 2, new DateTimeOffset(new DateTime(2024, 9, 28, 20, 13, 22, 584, DateTimeKind.Unspecified).AddTicks(286), new TimeSpan(0, -3, 0, 0, 0)), 102, "Terraza" },
                    { 3, 6, new DateTimeOffset(new DateTime(2024, 9, 28, 20, 13, 22, 584, DateTimeKind.Unspecified).AddTicks(287), new TimeSpan(0, -3, 0, 0, 0)), 103, "Interior" },
                    { 4, 4, new DateTimeOffset(new DateTime(2024, 9, 28, 20, 13, 22, 584, DateTimeKind.Unspecified).AddTicks(288), new TimeSpan(0, -3, 0, 0, 0)), 104, "Patio" },
                    { 5, 8, new DateTimeOffset(new DateTime(2024, 9, 28, 20, 13, 22, 584, DateTimeKind.Unspecified).AddTicks(288), new TimeSpan(0, -3, 0, 0, 0)), 105, "Terraza" },
                    { 6, 2, new DateTimeOffset(new DateTime(2024, 9, 28, 20, 13, 22, 584, DateTimeKind.Unspecified).AddTicks(289), new TimeSpan(0, -3, 0, 0, 0)), 106, "Interior" },
                    { 7, 6, new DateTimeOffset(new DateTime(2024, 9, 28, 20, 13, 22, 584, DateTimeKind.Unspecified).AddTicks(290), new TimeSpan(0, -3, 0, 0, 0)), 107, "Terraza" },
                    { 8, 4, new DateTimeOffset(new DateTime(2024, 9, 28, 20, 13, 22, 584, DateTimeKind.Unspecified).AddTicks(291), new TimeSpan(0, -3, 0, 0, 0)), 108, "Interior" },
                    { 9, 2, new DateTimeOffset(new DateTime(2024, 9, 28, 20, 13, 22, 584, DateTimeKind.Unspecified).AddTicks(291), new TimeSpan(0, -3, 0, 0, 0)), 109, "Interior" },
                    { 10, 6, new DateTimeOffset(new DateTime(2024, 9, 28, 20, 13, 22, 584, DateTimeKind.Unspecified).AddTicks(292), new TimeSpan(0, -3, 0, 0, 0)), 110, "Terraza" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Descripcion" },
                values: new object[,]
                {
                    { 1, "Mozo" },
                    { 2, "Chef" },
                    { 3, "Bartender" },
                    { 4, "Cajero" },
                    { 5, "Gerente" }
                });

            migrationBuilder.InsertData(
                table: "Empleados",
                columns: new[] { "Id", "Categoria", "FechaContratacion", "FechaCreacion", "Nombre", "Password", "RolId", "Salario", "Ubicacion", "UserName" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2024, 9, 28, 20, 13, 22, 584, DateTimeKind.Local).AddTicks(265), new DateTimeOffset(new DateTime(2024, 9, 28, 20, 13, 22, 584, DateTimeKind.Unspecified).AddTicks(244), new TimeSpan(0, -3, 0, 0, 0)), "Juan Perez", "1234", 1, 2000m, "Interior", "jperez" },
                    { 2, null, new DateTime(2024, 9, 28, 20, 13, 22, 584, DateTimeKind.Local).AddTicks(269), new DateTimeOffset(new DateTime(2024, 9, 28, 20, 13, 22, 584, DateTimeKind.Unspecified).AddTicks(268), new TimeSpan(0, -3, 0, 0, 0)), "Maria Garcia", "1234", 2, 2500m, "Cocina", "mgarcia" },
                    { 3, null, new DateTime(2024, 9, 28, 20, 13, 22, 584, DateTimeKind.Local).AddTicks(271), new DateTimeOffset(new DateTime(2024, 9, 28, 20, 13, 22, 584, DateTimeKind.Unspecified).AddTicks(270), new TimeSpan(0, -3, 0, 0, 0)), "Carlos Sanchez", "1234", 3, 2200m, "Bar", "csanchez" },
                    { 4, null, new DateTime(2024, 9, 28, 20, 13, 22, 584, DateTimeKind.Local).AddTicks(272), new DateTimeOffset(new DateTime(2024, 9, 28, 20, 13, 22, 584, DateTimeKind.Unspecified).AddTicks(271), new TimeSpan(0, -3, 0, 0, 0)), "Ana Lopez", "1234", 4, 2300m, "Caja", "alopez" },
                    { 5, null, new DateTime(2024, 9, 28, 20, 13, 22, 584, DateTimeKind.Local).AddTicks(273), new DateTimeOffset(new DateTime(2024, 9, 28, 20, 13, 22, 584, DateTimeKind.Unspecified).AddTicks(273), new TimeSpan(0, -3, 0, 0, 0)), "Roberto Diaz", "1234", 5, 3000m, "Oficina", "rdiaz" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comandas_MenuItemId",
                table: "Comandas",
                column: "MenuItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Comandas_OrdenId",
                table: "Comandas",
                column: "OrdenId");

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_RolId",
                table: "Empleados",
                column: "RolId");

            migrationBuilder.CreateIndex(
                name: "IX_Ordenes_EmpleadoId",
                table: "Ordenes",
                column: "EmpleadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Ordenes_MesaId",
                table: "Ordenes",
                column: "MesaId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenItems_MenuItemId",
                table: "OrdenItems",
                column: "MenuItemId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenItems_OrdenId",
                table: "OrdenItems",
                column: "OrdenId");

            migrationBuilder.CreateIndex(
                name: "IX_Pagos_OrdenId",
                table: "Pagos",
                column: "OrdenId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_MesaId",
                table: "Reservas",
                column: "MesaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comandas");

            migrationBuilder.DropTable(
                name: "OrdenItems");

            migrationBuilder.DropTable(
                name: "Pagos");

            migrationBuilder.DropTable(
                name: "Reservas");

            migrationBuilder.DropTable(
                name: "MenuItems");

            migrationBuilder.DropTable(
                name: "Ordenes");

            migrationBuilder.DropTable(
                name: "Empleados");

            migrationBuilder.DropTable(
                name: "Mesas");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
