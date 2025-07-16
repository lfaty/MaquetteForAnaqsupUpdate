using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MaquetteForAnaqsup.API.Migrations
{
    /// <inheritdoc />
    public partial class addattirbutsCMTDTPTPESEM : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CM",
                table: "ImportDatas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SEM",
                table: "ImportDatas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TD",
                table: "ImportDatas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TP",
                table: "ImportDatas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TPE",
                table: "ImportDatas",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CM",
                table: "ImportDatas");

            migrationBuilder.DropColumn(
                name: "SEM",
                table: "ImportDatas");

            migrationBuilder.DropColumn(
                name: "TD",
                table: "ImportDatas");

            migrationBuilder.DropColumn(
                name: "TP",
                table: "ImportDatas");

            migrationBuilder.DropColumn(
                name: "TPE",
                table: "ImportDatas");
        }
    }
}
