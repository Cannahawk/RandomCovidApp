using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FooBackBar.Migrations
{
    public partial class initial : Migration
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
                    Total = table.Column<int>(nullable: false),
                    Province = table.Column<string>(nullable: false)
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CaseHistories");

            migrationBuilder.DropTable(
                name: "Coordinates");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
