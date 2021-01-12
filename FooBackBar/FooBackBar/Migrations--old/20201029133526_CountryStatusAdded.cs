using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FooBackBar.Migrations
{
    public partial class CountryStatusAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "CountryStatus",
                columns: table => new
                {
                    Guid = table.Column<Guid>(nullable: false),
                    GuidCountry = table.Column<Guid>(nullable: false),
                    GuidStatus = table.Column<Guid>(nullable: false),
                    Total = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryStatus", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_CountryStatus_Countries_GuidCountry",
                        column: x => x.GuidCountry,
                        principalTable: "Countries",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CountryStatus_Status_GuidStatus",
                        column: x => x.GuidStatus,
                        principalTable: "Status",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_CountryStatus_GuidCountry",
                table: "CountryStatus",
                column: "GuidCountry");

            migrationBuilder.CreateIndex(
                name: "IX_CountryStatus_GuidStatus",
                table: "CountryStatus",
                column: "GuidStatus");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CountryStatus");

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
    }
}
