using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FooBackBar.Migrations
{
    public partial class countryUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Status",
                keyColumn: "Guid",
                keyValue: new Guid("7aff6beb-fda3-4903-9d4e-168e732179d2"));

            migrationBuilder.DeleteData(
                table: "Status",
                keyColumn: "Guid",
                keyValue: new Guid("7e3eae76-bd12-4927-845a-974f24bfd4c9"));

            migrationBuilder.DeleteData(
                table: "Status",
                keyColumn: "Guid",
                keyValue: new Guid("e0000fa0-3ccf-456d-8623-9d9199ae163d"));

            migrationBuilder.DropColumn(
                name: "Province",
                table: "Countries");

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Guid", "IsConfirmed", "IsDeath", "IsRecovered", "Total" },
                values: new object[] { new Guid("cce27126-5d6b-4cf1-bc1d-714168130497"), true, false, false, 0 });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Guid", "IsConfirmed", "IsDeath", "IsRecovered", "Total" },
                values: new object[] { new Guid("480c5c8f-1a6f-4200-97a2-b6a69acdc28c"), false, true, false, 0 });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Guid", "IsConfirmed", "IsDeath", "IsRecovered", "Total" },
                values: new object[] { new Guid("166412c3-6775-49e7-90e2-1ba8d7b9ed25"), false, false, true, 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Status",
                keyColumn: "Guid",
                keyValue: new Guid("166412c3-6775-49e7-90e2-1ba8d7b9ed25"));

            migrationBuilder.DeleteData(
                table: "Status",
                keyColumn: "Guid",
                keyValue: new Guid("480c5c8f-1a6f-4200-97a2-b6a69acdc28c"));

            migrationBuilder.DeleteData(
                table: "Status",
                keyColumn: "Guid",
                keyValue: new Guid("cce27126-5d6b-4cf1-bc1d-714168130497"));

            migrationBuilder.AddColumn<string>(
                name: "Province",
                table: "Countries",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Guid", "IsConfirmed", "IsDeath", "IsRecovered", "Total" },
                values: new object[] { new Guid("e0000fa0-3ccf-456d-8623-9d9199ae163d"), true, false, false, 0 });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Guid", "IsConfirmed", "IsDeath", "IsRecovered", "Total" },
                values: new object[] { new Guid("7e3eae76-bd12-4927-845a-974f24bfd4c9"), false, true, false, 0 });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Guid", "IsConfirmed", "IsDeath", "IsRecovered", "Total" },
                values: new object[] { new Guid("7aff6beb-fda3-4903-9d4e-168e732179d2"), false, false, true, 0 });
        }
    }
}
