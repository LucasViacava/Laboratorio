using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Laboratorio.Migrations
{
    public partial class AddFechaFinalizacionOrden : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "FechaFinalizacion",
                table: "Ordenes",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Empleados",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaContratacion", "FechaCreacion" },
                values: new object[] { new DateTime(2024, 9, 28, 21, 19, 9, 298, DateTimeKind.Local).AddTicks(8232), new DateTimeOffset(new DateTime(2024, 9, 28, 21, 19, 9, 298, DateTimeKind.Unspecified).AddTicks(8209), new TimeSpan(0, -3, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Empleados",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FechaContratacion", "FechaCreacion" },
                values: new object[] { new DateTime(2024, 9, 28, 21, 19, 9, 298, DateTimeKind.Local).AddTicks(8239), new DateTimeOffset(new DateTime(2024, 9, 28, 21, 19, 9, 298, DateTimeKind.Unspecified).AddTicks(8238), new TimeSpan(0, -3, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Empleados",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "FechaContratacion", "FechaCreacion" },
                values: new object[] { new DateTime(2024, 9, 28, 21, 19, 9, 298, DateTimeKind.Local).AddTicks(8240), new DateTimeOffset(new DateTime(2024, 9, 28, 21, 19, 9, 298, DateTimeKind.Unspecified).AddTicks(8240), new TimeSpan(0, -3, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Empleados",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "FechaContratacion", "FechaCreacion" },
                values: new object[] { new DateTime(2024, 9, 28, 21, 19, 9, 298, DateTimeKind.Local).AddTicks(8242), new DateTimeOffset(new DateTime(2024, 9, 28, 21, 19, 9, 298, DateTimeKind.Unspecified).AddTicks(8241), new TimeSpan(0, -3, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Empleados",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "FechaContratacion", "FechaCreacion" },
                values: new object[] { new DateTime(2024, 9, 28, 21, 19, 9, 298, DateTimeKind.Local).AddTicks(8243), new DateTimeOffset(new DateTime(2024, 9, 28, 21, 19, 9, 298, DateTimeKind.Unspecified).AddTicks(8242), new TimeSpan(0, -3, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCreacion",
                value: new DateTimeOffset(new DateTime(2024, 9, 28, 21, 19, 9, 298, DateTimeKind.Unspecified).AddTicks(8270), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCreacion",
                value: new DateTimeOffset(new DateTime(2024, 9, 28, 21, 19, 9, 298, DateTimeKind.Unspecified).AddTicks(8273), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaCreacion",
                value: new DateTimeOffset(new DateTime(2024, 9, 28, 21, 19, 9, 298, DateTimeKind.Unspecified).AddTicks(8274), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 4,
                column: "FechaCreacion",
                value: new DateTimeOffset(new DateTime(2024, 9, 28, 21, 19, 9, 298, DateTimeKind.Unspecified).AddTicks(8275), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 5,
                column: "FechaCreacion",
                value: new DateTimeOffset(new DateTime(2024, 9, 28, 21, 19, 9, 298, DateTimeKind.Unspecified).AddTicks(8276), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 6,
                column: "FechaCreacion",
                value: new DateTimeOffset(new DateTime(2024, 9, 28, 21, 19, 9, 298, DateTimeKind.Unspecified).AddTicks(8277), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 7,
                column: "FechaCreacion",
                value: new DateTimeOffset(new DateTime(2024, 9, 28, 21, 19, 9, 298, DateTimeKind.Unspecified).AddTicks(8278), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 8,
                column: "FechaCreacion",
                value: new DateTimeOffset(new DateTime(2024, 9, 28, 21, 19, 9, 298, DateTimeKind.Unspecified).AddTicks(8279), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 9,
                column: "FechaCreacion",
                value: new DateTimeOffset(new DateTime(2024, 9, 28, 21, 19, 9, 298, DateTimeKind.Unspecified).AddTicks(8280), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 10,
                column: "FechaCreacion",
                value: new DateTimeOffset(new DateTime(2024, 9, 28, 21, 19, 9, 298, DateTimeKind.Unspecified).AddTicks(8280), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Mesas",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCreacion",
                value: new DateTimeOffset(new DateTime(2024, 9, 28, 21, 19, 9, 298, DateTimeKind.Unspecified).AddTicks(8252), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Mesas",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCreacion",
                value: new DateTimeOffset(new DateTime(2024, 9, 28, 21, 19, 9, 298, DateTimeKind.Unspecified).AddTicks(8254), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Mesas",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaCreacion",
                value: new DateTimeOffset(new DateTime(2024, 9, 28, 21, 19, 9, 298, DateTimeKind.Unspecified).AddTicks(8255), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Mesas",
                keyColumn: "Id",
                keyValue: 4,
                column: "FechaCreacion",
                value: new DateTimeOffset(new DateTime(2024, 9, 28, 21, 19, 9, 298, DateTimeKind.Unspecified).AddTicks(8256), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Mesas",
                keyColumn: "Id",
                keyValue: 5,
                column: "FechaCreacion",
                value: new DateTimeOffset(new DateTime(2024, 9, 28, 21, 19, 9, 298, DateTimeKind.Unspecified).AddTicks(8257), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Mesas",
                keyColumn: "Id",
                keyValue: 6,
                column: "FechaCreacion",
                value: new DateTimeOffset(new DateTime(2024, 9, 28, 21, 19, 9, 298, DateTimeKind.Unspecified).AddTicks(8258), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Mesas",
                keyColumn: "Id",
                keyValue: 7,
                column: "FechaCreacion",
                value: new DateTimeOffset(new DateTime(2024, 9, 28, 21, 19, 9, 298, DateTimeKind.Unspecified).AddTicks(8258), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Mesas",
                keyColumn: "Id",
                keyValue: 8,
                column: "FechaCreacion",
                value: new DateTimeOffset(new DateTime(2024, 9, 28, 21, 19, 9, 298, DateTimeKind.Unspecified).AddTicks(8259), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Mesas",
                keyColumn: "Id",
                keyValue: 9,
                column: "FechaCreacion",
                value: new DateTimeOffset(new DateTime(2024, 9, 28, 21, 19, 9, 298, DateTimeKind.Unspecified).AddTicks(8260), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Mesas",
                keyColumn: "Id",
                keyValue: 10,
                column: "FechaCreacion",
                value: new DateTimeOffset(new DateTime(2024, 9, 28, 21, 19, 9, 298, DateTimeKind.Unspecified).AddTicks(8261), new TimeSpan(0, -3, 0, 0, 0)));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FechaFinalizacion",
                table: "Ordenes");

            migrationBuilder.UpdateData(
                table: "Empleados",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaContratacion", "FechaCreacion" },
                values: new object[] { new DateTime(2024, 9, 28, 20, 53, 6, 24, DateTimeKind.Local).AddTicks(6811), new DateTimeOffset(new DateTime(2024, 9, 28, 20, 53, 6, 24, DateTimeKind.Unspecified).AddTicks(6788), new TimeSpan(0, -3, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Empleados",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FechaContratacion", "FechaCreacion" },
                values: new object[] { new DateTime(2024, 9, 28, 20, 53, 6, 24, DateTimeKind.Local).AddTicks(6817), new DateTimeOffset(new DateTime(2024, 9, 28, 20, 53, 6, 24, DateTimeKind.Unspecified).AddTicks(6816), new TimeSpan(0, -3, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Empleados",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "FechaContratacion", "FechaCreacion" },
                values: new object[] { new DateTime(2024, 9, 28, 20, 53, 6, 24, DateTimeKind.Local).AddTicks(6819), new DateTimeOffset(new DateTime(2024, 9, 28, 20, 53, 6, 24, DateTimeKind.Unspecified).AddTicks(6818), new TimeSpan(0, -3, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Empleados",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "FechaContratacion", "FechaCreacion" },
                values: new object[] { new DateTime(2024, 9, 28, 20, 53, 6, 24, DateTimeKind.Local).AddTicks(6820), new DateTimeOffset(new DateTime(2024, 9, 28, 20, 53, 6, 24, DateTimeKind.Unspecified).AddTicks(6820), new TimeSpan(0, -3, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Empleados",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "FechaContratacion", "FechaCreacion" },
                values: new object[] { new DateTime(2024, 9, 28, 20, 53, 6, 24, DateTimeKind.Local).AddTicks(6822), new DateTimeOffset(new DateTime(2024, 9, 28, 20, 53, 6, 24, DateTimeKind.Unspecified).AddTicks(6821), new TimeSpan(0, -3, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCreacion",
                value: new DateTimeOffset(new DateTime(2024, 9, 28, 20, 53, 6, 24, DateTimeKind.Unspecified).AddTicks(6847), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCreacion",
                value: new DateTimeOffset(new DateTime(2024, 9, 28, 20, 53, 6, 24, DateTimeKind.Unspecified).AddTicks(6849), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaCreacion",
                value: new DateTimeOffset(new DateTime(2024, 9, 28, 20, 53, 6, 24, DateTimeKind.Unspecified).AddTicks(6851), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 4,
                column: "FechaCreacion",
                value: new DateTimeOffset(new DateTime(2024, 9, 28, 20, 53, 6, 24, DateTimeKind.Unspecified).AddTicks(6852), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 5,
                column: "FechaCreacion",
                value: new DateTimeOffset(new DateTime(2024, 9, 28, 20, 53, 6, 24, DateTimeKind.Unspecified).AddTicks(6853), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 6,
                column: "FechaCreacion",
                value: new DateTimeOffset(new DateTime(2024, 9, 28, 20, 53, 6, 24, DateTimeKind.Unspecified).AddTicks(6853), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 7,
                column: "FechaCreacion",
                value: new DateTimeOffset(new DateTime(2024, 9, 28, 20, 53, 6, 24, DateTimeKind.Unspecified).AddTicks(6854), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 8,
                column: "FechaCreacion",
                value: new DateTimeOffset(new DateTime(2024, 9, 28, 20, 53, 6, 24, DateTimeKind.Unspecified).AddTicks(6855), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 9,
                column: "FechaCreacion",
                value: new DateTimeOffset(new DateTime(2024, 9, 28, 20, 53, 6, 24, DateTimeKind.Unspecified).AddTicks(6856), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 10,
                column: "FechaCreacion",
                value: new DateTimeOffset(new DateTime(2024, 9, 28, 20, 53, 6, 24, DateTimeKind.Unspecified).AddTicks(6857), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Mesas",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCreacion",
                value: new DateTimeOffset(new DateTime(2024, 9, 28, 20, 53, 6, 24, DateTimeKind.Unspecified).AddTicks(6829), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Mesas",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCreacion",
                value: new DateTimeOffset(new DateTime(2024, 9, 28, 20, 53, 6, 24, DateTimeKind.Unspecified).AddTicks(6831), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Mesas",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaCreacion",
                value: new DateTimeOffset(new DateTime(2024, 9, 28, 20, 53, 6, 24, DateTimeKind.Unspecified).AddTicks(6832), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Mesas",
                keyColumn: "Id",
                keyValue: 4,
                column: "FechaCreacion",
                value: new DateTimeOffset(new DateTime(2024, 9, 28, 20, 53, 6, 24, DateTimeKind.Unspecified).AddTicks(6833), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Mesas",
                keyColumn: "Id",
                keyValue: 5,
                column: "FechaCreacion",
                value: new DateTimeOffset(new DateTime(2024, 9, 28, 20, 53, 6, 24, DateTimeKind.Unspecified).AddTicks(6833), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Mesas",
                keyColumn: "Id",
                keyValue: 6,
                column: "FechaCreacion",
                value: new DateTimeOffset(new DateTime(2024, 9, 28, 20, 53, 6, 24, DateTimeKind.Unspecified).AddTicks(6834), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Mesas",
                keyColumn: "Id",
                keyValue: 7,
                column: "FechaCreacion",
                value: new DateTimeOffset(new DateTime(2024, 9, 28, 20, 53, 6, 24, DateTimeKind.Unspecified).AddTicks(6835), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Mesas",
                keyColumn: "Id",
                keyValue: 8,
                column: "FechaCreacion",
                value: new DateTimeOffset(new DateTime(2024, 9, 28, 20, 53, 6, 24, DateTimeKind.Unspecified).AddTicks(6836), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Mesas",
                keyColumn: "Id",
                keyValue: 9,
                column: "FechaCreacion",
                value: new DateTimeOffset(new DateTime(2024, 9, 28, 20, 53, 6, 24, DateTimeKind.Unspecified).AddTicks(6836), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Mesas",
                keyColumn: "Id",
                keyValue: 10,
                column: "FechaCreacion",
                value: new DateTimeOffset(new DateTime(2024, 9, 28, 20, 53, 6, 24, DateTimeKind.Unspecified).AddTicks(6837), new TimeSpan(0, -3, 0, 0, 0)));
        }
    }
}
