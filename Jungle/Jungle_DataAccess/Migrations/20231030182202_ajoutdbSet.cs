using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jungle_DataAccess.Migrations
{
    public partial class ajoutdbSet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OptionReservation_Option_OptionsId",
                table: "OptionReservation");

            migrationBuilder.DropForeignKey(
                name: "FK_Travels_Option_OptionId",
                table: "Travels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Option",
                table: "Option");

            migrationBuilder.RenameTable(
                name: "Option",
                newName: "Options");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Options",
                table: "Options",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OptionReservation_Options_OptionsId",
                table: "OptionReservation",
                column: "OptionsId",
                principalTable: "Options",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Travels_Options_OptionId",
                table: "Travels",
                column: "OptionId",
                principalTable: "Options",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OptionReservation_Options_OptionsId",
                table: "OptionReservation");

            migrationBuilder.DropForeignKey(
                name: "FK_Travels_Options_OptionId",
                table: "Travels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Options",
                table: "Options");

            migrationBuilder.RenameTable(
                name: "Options",
                newName: "Option");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Option",
                table: "Option",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OptionReservation_Option_OptionsId",
                table: "OptionReservation",
                column: "OptionsId",
                principalTable: "Option",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Travels_Option_OptionId",
                table: "Travels",
                column: "OptionId",
                principalTable: "Option",
                principalColumn: "Id");
        }
    }
}
