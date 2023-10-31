using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jungle_DataAccess.Migrations
{
    public partial class addAnnotationTypePrixOption : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Travels_Options_OptionId",
                table: "Travels");

            migrationBuilder.DropIndex(
                name: "IX_Travels_OptionId",
                table: "Travels");

            migrationBuilder.DropColumn(
                name: "OptionId",
                table: "Travels");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Reservations",
                type: "varchar(25)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<double>(
                name: "Prix",
                table: "Options",
                type: "float",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Options",
                type: "varchar(MAX)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "OptionTravel",
                columns: table => new
                {
                    OptionsId = table.Column<int>(type: "int", nullable: false),
                    TravelsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OptionTravel", x => new { x.OptionsId, x.TravelsId });
                    table.ForeignKey(
                        name: "FK_OptionTravel_Options_OptionsId",
                        column: x => x.OptionsId,
                        principalTable: "Options",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OptionTravel_Travels_TravelsId",
                        column: x => x.TravelsId,
                        principalTable: "Travels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OptionTravel_TravelsId",
                table: "OptionTravel",
                column: "TravelsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OptionTravel");

            migrationBuilder.AddColumn<int>(
                name: "OptionId",
                table: "Travels",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Reservations",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(25)");

            migrationBuilder.AlterColumn<string>(
                name: "Prix",
                table: "Options",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Options",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(MAX)");

            migrationBuilder.CreateIndex(
                name: "IX_Travels_OptionId",
                table: "Travels",
                column: "OptionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Travels_Options_OptionId",
                table: "Travels",
                column: "OptionId",
                principalTable: "Options",
                principalColumn: "Id");
        }
    }
}
