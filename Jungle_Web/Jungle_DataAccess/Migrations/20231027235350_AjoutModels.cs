using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jungle_DataAccess.Migrations
{
    public partial class AjoutModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "guides",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Speciality = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_guides", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "destinations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Region = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_destinations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_destinations_countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "travelRecommendations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DangerLevel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TravelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_travelRecommendations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "travels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    DepartureDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    DestinationId = table.Column<int>(type: "int", nullable: false),
                    TravelRecommendationId = table.Column<int>(type: "int", nullable: true),
                    GuideId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_travels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_travels_destinations_DestinationId",
                        column: x => x.DestinationId,
                        principalTable: "destinations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_travels_guides_GuideId",
                        column: x => x.GuideId,
                        principalTable: "guides",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_travels_travelRecommendations_TravelRecommendationId",
                        column: x => x.TravelRecommendationId,
                        principalTable: "travelRecommendations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_destinations_CountryId",
                table: "destinations",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_travelRecommendations_TravelId",
                table: "travelRecommendations",
                column: "TravelId");

            migrationBuilder.CreateIndex(
                name: "IX_travels_DestinationId",
                table: "travels",
                column: "DestinationId");

            migrationBuilder.CreateIndex(
                name: "IX_travels_GuideId",
                table: "travels",
                column: "GuideId");

            migrationBuilder.CreateIndex(
                name: "IX_travels_TravelRecommendationId",
                table: "travels",
                column: "TravelRecommendationId");

            migrationBuilder.AddForeignKey(
                name: "FK_travelRecommendations_travels_TravelId",
                table: "travelRecommendations",
                column: "TravelId",
                principalTable: "travels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_destinations_countries_CountryId",
                table: "destinations");

            migrationBuilder.DropForeignKey(
                name: "FK_travelRecommendations_travels_TravelId",
                table: "travelRecommendations");

            migrationBuilder.DropTable(
                name: "countries");

            migrationBuilder.DropTable(
                name: "travels");

            migrationBuilder.DropTable(
                name: "destinations");

            migrationBuilder.DropTable(
                name: "guides");

            migrationBuilder.DropTable(
                name: "travelRecommendations");
        }
    }
}
