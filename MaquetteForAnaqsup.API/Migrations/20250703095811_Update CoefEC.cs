using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MaquetteForAnaqsup.API.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCoefEC : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AtomePedagogique",
                table: "ImportDatas");

            migrationBuilder.DropColumn(
                name: "VolumeHoraire",
                table: "ImportDatas");

            migrationBuilder.AlterColumn<decimal>(
                name: "CoefEC",
                table: "ImportDatas",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CoefEC",
                table: "ImportDatas",
                type: "int",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AtomePedagogique",
                table: "ImportDatas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VolumeHoraire",
                table: "ImportDatas",
                type: "int",
                nullable: true);
        }
    }
}
