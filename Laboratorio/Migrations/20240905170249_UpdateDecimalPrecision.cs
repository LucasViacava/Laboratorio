using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Laboratorio.Migrations
{
    public partial class UpdateDecimalPrecision : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Comandas",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCreacion",
                value: new DateTimeOffset(new DateTime(2024, 9, 5, 14, 2, 48, 836, DateTimeKind.Unspecified).AddTicks(5343), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Comandas",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCreacion",
                value: new DateTimeOffset(new DateTime(2024, 9, 5, 14, 2, 48, 836, DateTimeKind.Unspecified).AddTicks(5365), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Comandas",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaCreacion",
                value: new DateTimeOffset(new DateTime(2024, 9, 5, 14, 2, 48, 836, DateTimeKind.Unspecified).AddTicks(5368), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Comandas",
                keyColumn: "Id",
                keyValue: 4,
                column: "FechaCreacion",
                value: new DateTimeOffset(new DateTime(2024, 9, 5, 14, 2, 48, 836, DateTimeKind.Unspecified).AddTicks(5370), new TimeSpan(0, -3, 0, 0, 0)));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Comandas",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCreacion",
                value: new DateTimeOffset(new DateTime(2024, 9, 5, 13, 59, 15, 800, DateTimeKind.Unspecified).AddTicks(7233), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Comandas",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCreacion",
                value: new DateTimeOffset(new DateTime(2024, 9, 5, 13, 59, 15, 800, DateTimeKind.Unspecified).AddTicks(7253), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Comandas",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaCreacion",
                value: new DateTimeOffset(new DateTime(2024, 9, 5, 13, 59, 15, 800, DateTimeKind.Unspecified).AddTicks(7255), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Comandas",
                keyColumn: "Id",
                keyValue: 4,
                column: "FechaCreacion",
                value: new DateTimeOffset(new DateTime(2024, 9, 5, 13, 59, 15, 800, DateTimeKind.Unspecified).AddTicks(7258), new TimeSpan(0, -3, 0, 0, 0)));
        }
    }
}
