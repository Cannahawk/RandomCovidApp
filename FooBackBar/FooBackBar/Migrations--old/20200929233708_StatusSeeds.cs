using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FooBackBar.Migrations
{
    public partial class StatusSeeds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Guid", "IsConfirmed", "IsDeath", "IsRecovered", "Total" },
                values: new object[] { new Guid("2313ee8a-47ed-4a4f-94ac-35382658b3d0"), true, false, false, 0 });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Guid", "IsConfirmed", "IsDeath", "IsRecovered", "Total" },
                values: new object[] { new Guid("04f7ce06-59fb-4cfa-ae87-0f5a3f604d7e"), false, true, false, 0 });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Guid", "IsConfirmed", "IsDeath", "IsRecovered", "Total" },
                values: new object[] { new Guid("3ea1615d-c001-48a8-b650-5875e0a1ec9b"), false, false, true, 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Status",
                keyColumn: "Guid",
                keyValue: new Guid("04f7ce06-59fb-4cfa-ae87-0f5a3f604d7e"));

            migrationBuilder.DeleteData(
                table: "Status",
                keyColumn: "Guid",
                keyValue: new Guid("2313ee8a-47ed-4a4f-94ac-35382658b3d0"));

            migrationBuilder.DeleteData(
                table: "Status",
                keyColumn: "Guid",
                keyValue: new Guid("3ea1615d-c001-48a8-b650-5875e0a1ec9b"));
        }
    }
}
