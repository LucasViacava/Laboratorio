using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Laboratorio.Migrations
{
    public partial class AddTiempoPreparacionToMenuItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TiempoPreparacion",
                table: "MenuItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
                columns: new[] { "FechaCreacion", "TiempoPreparacion" },
                values: new object[] { new DateTimeOffset(new DateTime(2024, 9, 28, 20, 53, 6, 24, DateTimeKind.Unspecified).AddTicks(6847), new TimeSpan(0, -3, 0, 0, 0)), 15 });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FechaCreacion", "TiempoPreparacion" },
                values: new object[] { new DateTimeOffset(new DateTime(2024, 9, 28, 20, 53, 6, 24, DateTimeKind.Unspecified).AddTicks(6849), new TimeSpan(0, -3, 0, 0, 0)), 10 });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "FechaCreacion", "TiempoPreparacion" },
                values: new object[] { new DateTimeOffset(new DateTime(2024, 9, 28, 20, 53, 6, 24, DateTimeKind.Unspecified).AddTicks(6851), new TimeSpan(0, -3, 0, 0, 0)), 5 });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "FechaCreacion", "TiempoPreparacion" },
                values: new object[] { new DateTimeOffset(new DateTime(2024, 9, 28, 20, 53, 6, 24, DateTimeKind.Unspecified).AddTicks(6852), new TimeSpan(0, -3, 0, 0, 0)), 20 });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "FechaCreacion", "TiempoPreparacion" },
                values: new object[] { new DateTimeOffset(new DateTime(2024, 9, 28, 20, 53, 6, 24, DateTimeKind.Unspecified).AddTicks(6853), new TimeSpan(0, -3, 0, 0, 0)), 18 });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "FechaCreacion", "TiempoPreparacion" },
                values: new object[] { new DateTimeOffset(new DateTime(2024, 9, 28, 20, 53, 6, 24, DateTimeKind.Unspecified).AddTicks(6853), new TimeSpan(0, -3, 0, 0, 0)), 12 });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "FechaCreacion", "TiempoPreparacion" },
                values: new object[] { new DateTimeOffset(new DateTime(2024, 9, 28, 20, 53, 6, 24, DateTimeKind.Unspecified).AddTicks(6854), new TimeSpan(0, -3, 0, 0, 0)), 1 });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "FechaCreacion", "TiempoPreparacion" },
                values: new object[] { new DateTimeOffset(new DateTime(2024, 9, 28, 20, 53, 6, 24, DateTimeKind.Unspecified).AddTicks(6855), new TimeSpan(0, -3, 0, 0, 0)), 7 });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "FechaCreacion", "TiempoPreparacion" },
                values: new object[] { new DateTimeOffset(new DateTime(2024, 9, 28, 20, 53, 6, 24, DateTimeKind.Unspecified).AddTicks(6856), new TimeSpan(0, -3, 0, 0, 0)), 2 });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "FechaCreacion", "TiempoPreparacion" },
                values: new object[] { new DateTimeOffset(new DateTime(2024, 9, 28, 20, 53, 6, 24, DateTimeKind.Unspecified).AddTicks(6857), new TimeSpan(0, -3, 0, 0, 0)), 9 });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TiempoPreparacion",
                table: "MenuItems");

            migrationBuilder.UpdateData(
                table: "Empleados",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaContratacion", "FechaCreacion" },
                values: new object[] { new DateTime(2024, 9, 28, 20, 13, 22, 584, DateTimeKind.Local).AddTicks(265), new DateTimeOffset(new DateTime(2024, 9, 28, 20, 13, 22, 584, DateTimeKind.Unspecified).AddTicks(244), new TimeSpan(0, -3, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Empleados",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FechaContratacion", "FechaCreacion" },
                values: new object[] { new DateTime(2024, 9, 28, 20, 13, 22, 584, DateTimeKind.Local).AddTicks(269), new DateTimeOffset(new DateTime(2024, 9, 28, 20, 13, 22, 584, DateTimeKind.Unspecified).AddTicks(268), new TimeSpan(0, -3, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Empleados",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "FechaContratacion", "FechaCreacion" },
                values: new object[] { new DateTime(2024, 9, 28, 20, 13, 22, 584, DateTimeKind.Local).AddTicks(271), new DateTimeOffset(new DateTime(2024, 9, 28, 20, 13, 22, 584, DateTimeKind.Unspecified).AddTicks(270), new TimeSpan(0, -3, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Empleados",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "FechaContratacion", "FechaCreacion" },
                values: new object[] { new DateTime(2024, 9, 28, 20, 13, 22, 584, DateTimeKind.Local).AddTicks(272), new DateTimeOffset(new DateTime(2024, 9, 28, 20, 13, 22, 584, DateTimeKind.Unspecified).AddTicks(271), new TimeSpan(0, -3, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Empleados",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "FechaContratacion", "FechaCreacion" },
                values: new object[] { new DateTime(2024, 9, 28, 20, 13, 22, 584, DateTimeKind.Local).AddTicks(273), new DateTimeOffset(new DateTime(2024, 9, 28, 20, 13, 22, 584, DateTimeKind.Unspecified).AddTicks(273), new TimeSpan(0, -3, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCreacion",
                value: new DateTimeOffset(new DateTime(2024, 9, 28, 20, 13, 22, 584, DateTimeKind.Unspecified).AddTicks(302), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCreacion",
                value: new DateTimeOffset(new DateTime(2024, 9, 28, 20, 13, 22, 584, DateTimeKind.Unspecified).AddTicks(304), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaCreacion",
                value: new DateTimeOffset(new DateTime(2024, 9, 28, 20, 13, 22, 584, DateTimeKind.Unspecified).AddTicks(305), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 4,
                column: "FechaCreacion",
                value: new DateTimeOffset(new DateTime(2024, 9, 28, 20, 13, 22, 584, DateTimeKind.Unspecified).AddTicks(306), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 5,
                column: "FechaCreacion",
                value: new DateTimeOffset(new DateTime(2024, 9, 28, 20, 13, 22, 584, DateTimeKind.Unspecified).AddTicks(307), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 6,
                column: "FechaCreacion",
                value: new DateTimeOffset(new DateTime(2024, 9, 28, 20, 13, 22, 584, DateTimeKind.Unspecified).AddTicks(308), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 7,
                column: "FechaCreacion",
                value: new DateTimeOffset(new DateTime(2024, 9, 28, 20, 13, 22, 584, DateTimeKind.Unspecified).AddTicks(308), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 8,
                column: "FechaCreacion",
                value: new DateTimeOffset(new DateTime(2024, 9, 28, 20, 13, 22, 584, DateTimeKind.Unspecified).AddTicks(309), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 9,
                column: "FechaCreacion",
                value: new DateTimeOffset(new DateTime(2024, 9, 28, 20, 13, 22, 584, DateTimeKind.Unspecified).AddTicks(310), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 10,
                column: "FechaCreacion",
                value: new DateTimeOffset(new DateTime(2024, 9, 28, 20, 13, 22, 584, DateTimeKind.Unspecified).AddTicks(311), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Mesas",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCreacion",
                value: new DateTimeOffset(new DateTime(2024, 9, 28, 20, 13, 22, 584, DateTimeKind.Unspecified).AddTicks(283), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Mesas",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCreacion",
                value: new DateTimeOffset(new DateTime(2024, 9, 28, 20, 13, 22, 584, DateTimeKind.Unspecified).AddTicks(286), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Mesas",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaCreacion",
                value: new DateTimeOffset(new DateTime(2024, 9, 28, 20, 13, 22, 584, DateTimeKind.Unspecified).AddTicks(287), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Mesas",
                keyColumn: "Id",
                keyValue: 4,
                column: "FechaCreacion",
                value: new DateTimeOffset(new DateTime(2024, 9, 28, 20, 13, 22, 584, DateTimeKind.Unspecified).AddTicks(288), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Mesas",
                keyColumn: "Id",
                keyValue: 5,
                column: "FechaCreacion",
                value: new DateTimeOffset(new DateTime(2024, 9, 28, 20, 13, 22, 584, DateTimeKind.Unspecified).AddTicks(288), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Mesas",
                keyColumn: "Id",
                keyValue: 6,
                column: "FechaCreacion",
                value: new DateTimeOffset(new DateTime(2024, 9, 28, 20, 13, 22, 584, DateTimeKind.Unspecified).AddTicks(289), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Mesas",
                keyColumn: "Id",
                keyValue: 7,
                column: "FechaCreacion",
                value: new DateTimeOffset(new DateTime(2024, 9, 28, 20, 13, 22, 584, DateTimeKind.Unspecified).AddTicks(290), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Mesas",
                keyColumn: "Id",
                keyValue: 8,
                column: "FechaCreacion",
                value: new DateTimeOffset(new DateTime(2024, 9, 28, 20, 13, 22, 584, DateTimeKind.Unspecified).AddTicks(291), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Mesas",
                keyColumn: "Id",
                keyValue: 9,
                column: "FechaCreacion",
                value: new DateTimeOffset(new DateTime(2024, 9, 28, 20, 13, 22, 584, DateTimeKind.Unspecified).AddTicks(291), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Mesas",
                keyColumn: "Id",
                keyValue: 10,
                column: "FechaCreacion",
                value: new DateTimeOffset(new DateTime(2024, 9, 28, 20, 13, 22, 584, DateTimeKind.Unspecified).AddTicks(292), new TimeSpan(0, -3, 0, 0, 0)));
        }
    }
}
