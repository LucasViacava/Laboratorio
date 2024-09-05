using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Laboratorio.Migrations
{
    public partial class seedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NombreCliente",
                table: "Reservas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "MenuItems",
                columns: new[] { "Id", "Categoria", "Descripcion", "FechaCreacion", "Nombre", "Precio" },
                values: new object[,]
                {
                    { 1, null, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Milanesa a Caballo", 800m },
                    { 2, null, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Hamburguesa de Garbanzo", 500m },
                    { 3, null, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Corona", 200m },
                    { 4, null, null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Daikiri", 300m }
                });

            migrationBuilder.InsertData(
                table: "Comandas",
                columns: new[] { "Id", "Cantidad", "Estado", "FechaCreacion", "MenuItemId", "Pedido", "PedidoId" },
                values: new object[,]
                {
                    { 1, 1, "En Preparación", new DateTimeOffset(new DateTime(2024, 9, 5, 13, 59, 15, 800, DateTimeKind.Unspecified).AddTicks(7233), new TimeSpan(0, -3, 0, 0, 0)), 1, "", 1 },
                    { 2, 2, "En Preparación", new DateTimeOffset(new DateTime(2024, 9, 5, 13, 59, 15, 800, DateTimeKind.Unspecified).AddTicks(7253), new TimeSpan(0, -3, 0, 0, 0)), 2, "", 1 },
                    { 3, 1, "En Preparación", new DateTimeOffset(new DateTime(2024, 9, 5, 13, 59, 15, 800, DateTimeKind.Unspecified).AddTicks(7255), new TimeSpan(0, -3, 0, 0, 0)), 3, "", 1 },
                    { 4, 1, "En Preparación", new DateTimeOffset(new DateTime(2024, 9, 5, 13, 59, 15, 800, DateTimeKind.Unspecified).AddTicks(7258), new TimeSpan(0, -3, 0, 0, 0)), 4, "", 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Comandas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Comandas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Comandas",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Comandas",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DropColumn(
                name: "NombreCliente",
                table: "Reservas");
        }
    }
}
