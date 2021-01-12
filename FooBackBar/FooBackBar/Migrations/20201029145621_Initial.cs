using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FooBackBar.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Guid = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Code = table.Column<string>(nullable: false),
                    Total = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    Guid = table.Column<Guid>(nullable: false),
                    Total = table.Column<int>(nullable: false),
                    IsConfirmed = table.Column<bool>(nullable: false),
                    IsDeath = table.Column<bool>(nullable: false),
                    IsRecovered = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "Coordinates",
                columns: table => new
                {
                    Guid = table.Column<Guid>(nullable: false),
                    GuidCountry = table.Column<Guid>(nullable: false),
                    Latitude = table.Column<decimal>(nullable: false),
                    Longitude = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coordinates", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_Coordinates_Countries_GuidCountry",
                        column: x => x.GuidCountry,
                        principalTable: "Countries",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CaseHistories",
                columns: table => new
                {
                    Guid = table.Column<Guid>(nullable: false),
                    GuidCountry = table.Column<Guid>(nullable: false),
                    GuidStatus = table.Column<Guid>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Amount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaseHistories", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_CaseHistories_Countries_GuidCountry",
                        column: x => x.GuidCountry,
                        principalTable: "Countries",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CaseHistories_Status_GuidStatus",
                        column: x => x.GuidStatus,
                        principalTable: "Status",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

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
                values: new object[] { new Guid("f86de47f-b7cb-465f-b999-3ad52c32f02e"), true, false, false, 0 });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Guid", "IsConfirmed", "IsDeath", "IsRecovered", "Total" },
                values: new object[] { new Guid("1722f575-7dda-41f8-8ef9-155f6b36f609"), false, true, false, 0 });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Guid", "IsConfirmed", "IsDeath", "IsRecovered", "Total" },
                values: new object[] { new Guid("d8f6bc61-edcd-4b65-9ae0-af17487fa4e2"), false, false, true, 0 });

            migrationBuilder.CreateIndex(
                name: "IX_CaseHistories_GuidCountry",
                table: "CaseHistories",
                column: "GuidCountry");

            migrationBuilder.CreateIndex(
                name: "IX_CaseHistories_GuidStatus",
                table: "CaseHistories",
                column: "GuidStatus");

            migrationBuilder.CreateIndex(
                name: "IX_Coordinates_GuidCountry",
                table: "Coordinates",
                column: "GuidCountry",
                unique: true);

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
                name: "CaseHistories");

            migrationBuilder.DropTable(
                name: "Coordinates");

            migrationBuilder.DropTable(
                name: "CountryStatus");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Status");
        }
    }
}
