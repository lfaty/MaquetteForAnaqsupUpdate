using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MaquetteForAnaqsup.API.Migrations
{
    /// <inheritdoc />
    public partial class UpdateModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AtomeElementConstitutif_AtomePedagogique",
                table: "AtomeElementConstitutifs");

            migrationBuilder.DropForeignKey(
                name: "FK_AtomeElementConstitutif_ElementConstitutif",
                table: "AtomeElementConstitutifs");

            migrationBuilder.DropForeignKey(
                name: "FK_Debouche_Formation",
                table: "Debouches");

            migrationBuilder.DropForeignKey(
                name: "FK_ElementConstitutif_UniteEnseignement",
                table: "ElementConstitutifs");

            migrationBuilder.DropIndex(
                name: "IX_Debouches_FormationId",
                table: "Debouches");

            migrationBuilder.DropColumn(
                name: "AnneeDebut",
                table: "Formations");

            migrationBuilder.DropColumn(
                name: "AnneeFin",
                table: "Formations");

            migrationBuilder.DropColumn(
                name: "FormationId",
                table: "Debouches");

            migrationBuilder.AddColumn<string>(
                name: "Annee",
                table: "Villes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Annee",
                table: "Universites",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Annee",
                table: "UniteEnseignements",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "FormationId",
                table: "UniteEnseignements",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Annee",
                table: "Specialites",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Annee",
                table: "Semestres",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Annee",
                table: "ParcourUniteEnseignements",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "FormationId",
                table: "ParcourUniteEnseignements",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Annee",
                table: "Parcours",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Annee",
                table: "Niveaus",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Annee",
                table: "NatureUniteEnseignements",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Annee",
                table: "Mentions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Annee",
                table: "Images",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Annee",
                table: "Grades",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Annee",
                table: "Formations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Annee",
                table: "Facultes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "UniteEnseignementId",
                table: "ElementConstitutifs",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<string>(
                name: "Annee",
                table: "ElementConstitutifs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "FormationId",
                table: "ElementConstitutifs",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Annee",
                table: "Domaines",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Annee",
                table: "Departements",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Annee",
                table: "Debouches",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Annee",
                table: "AtomePedagogiques",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ElementConstitutifId",
                table: "AtomeElementConstitutifs",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "AtomePedagogiqueId",
                table: "AtomeElementConstitutifs",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<string>(
                name: "Annee",
                table: "AtomeElementConstitutifs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "FormationId",
                table: "AtomeElementConstitutifs",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AnneeMaquettes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Libelle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Annee = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Struct = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Statut = table.Column<int>(type: "int", nullable: false),
                    DateStatut = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CodeUniv = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnneeMaquettes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FormationDebouches",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FormationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeboucheId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CodeUniv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Annee = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormationDebouches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FormationDebouche_Debouche",
                        column: x => x.DeboucheId,
                        principalTable: "Debouches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FormationDebouche_Formation",
                        column: x => x.FormationId,
                        principalTable: "Formations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UniversiteUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UniversiteId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoleId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Statut = table.Column<int>(type: "int", nullable: false),
                    DateStatut = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Annee = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodeUniv = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UniversiteUsers", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UniteEnseignements_FormationId",
                table: "UniteEnseignements",
                column: "FormationId");

            migrationBuilder.CreateIndex(
                name: "IX_ParcourUniteEnseignements_FormationId",
                table: "ParcourUniteEnseignements",
                column: "FormationId");

            migrationBuilder.CreateIndex(
                name: "IX_ElementConstitutifs_FormationId",
                table: "ElementConstitutifs",
                column: "FormationId");

            migrationBuilder.CreateIndex(
                name: "IX_AtomeElementConstitutifs_FormationId",
                table: "AtomeElementConstitutifs",
                column: "FormationId");

            migrationBuilder.CreateIndex(
                name: "IX_FormationDebouches_DeboucheId",
                table: "FormationDebouches",
                column: "DeboucheId");

            migrationBuilder.CreateIndex(
                name: "IX_FormationDebouches_FormationId",
                table: "FormationDebouches",
                column: "FormationId");

            migrationBuilder.AddForeignKey(
                name: "FK_AtomeElementConstitutif_AtomePedagogique",
                table: "AtomeElementConstitutifs",
                column: "AtomePedagogiqueId",
                principalTable: "AtomePedagogiques",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AtomeElementConstitutif_ElementConstitutif",
                table: "AtomeElementConstitutifs",
                column: "ElementConstitutifId",
                principalTable: "ElementConstitutifs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AtomeElementConstitutifs_Formations_FormationId",
                table: "AtomeElementConstitutifs",
                column: "FormationId",
                principalTable: "Formations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ElementConstitutif_UniteEnseignement",
                table: "ElementConstitutifs",
                column: "UniteEnseignementId",
                principalTable: "UniteEnseignements",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ElementConstitutifs_Formations_FormationId",
                table: "ElementConstitutifs",
                column: "FormationId",
                principalTable: "Formations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ParcourUniteEnseignements_Formations_FormationId",
                table: "ParcourUniteEnseignements",
                column: "FormationId",
                principalTable: "Formations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UniteEnseignements_Formations_FormationId",
                table: "UniteEnseignements",
                column: "FormationId",
                principalTable: "Formations",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AtomeElementConstitutif_AtomePedagogique",
                table: "AtomeElementConstitutifs");

            migrationBuilder.DropForeignKey(
                name: "FK_AtomeElementConstitutif_ElementConstitutif",
                table: "AtomeElementConstitutifs");

            migrationBuilder.DropForeignKey(
                name: "FK_AtomeElementConstitutifs_Formations_FormationId",
                table: "AtomeElementConstitutifs");

            migrationBuilder.DropForeignKey(
                name: "FK_ElementConstitutif_UniteEnseignement",
                table: "ElementConstitutifs");

            migrationBuilder.DropForeignKey(
                name: "FK_ElementConstitutifs_Formations_FormationId",
                table: "ElementConstitutifs");

            migrationBuilder.DropForeignKey(
                name: "FK_ParcourUniteEnseignements_Formations_FormationId",
                table: "ParcourUniteEnseignements");

            migrationBuilder.DropForeignKey(
                name: "FK_UniteEnseignements_Formations_FormationId",
                table: "UniteEnseignements");

            migrationBuilder.DropTable(
                name: "AnneeMaquettes");

            migrationBuilder.DropTable(
                name: "FormationDebouches");

            migrationBuilder.DropTable(
                name: "UniversiteUsers");

            migrationBuilder.DropIndex(
                name: "IX_UniteEnseignements_FormationId",
                table: "UniteEnseignements");

            migrationBuilder.DropIndex(
                name: "IX_ParcourUniteEnseignements_FormationId",
                table: "ParcourUniteEnseignements");

            migrationBuilder.DropIndex(
                name: "IX_ElementConstitutifs_FormationId",
                table: "ElementConstitutifs");

            migrationBuilder.DropIndex(
                name: "IX_AtomeElementConstitutifs_FormationId",
                table: "AtomeElementConstitutifs");

            migrationBuilder.DropColumn(
                name: "Annee",
                table: "Villes");

            migrationBuilder.DropColumn(
                name: "Annee",
                table: "Universites");

            migrationBuilder.DropColumn(
                name: "Annee",
                table: "UniteEnseignements");

            migrationBuilder.DropColumn(
                name: "FormationId",
                table: "UniteEnseignements");

            migrationBuilder.DropColumn(
                name: "Annee",
                table: "Specialites");

            migrationBuilder.DropColumn(
                name: "Annee",
                table: "Semestres");

            migrationBuilder.DropColumn(
                name: "Annee",
                table: "ParcourUniteEnseignements");

            migrationBuilder.DropColumn(
                name: "FormationId",
                table: "ParcourUniteEnseignements");

            migrationBuilder.DropColumn(
                name: "Annee",
                table: "Parcours");

            migrationBuilder.DropColumn(
                name: "Annee",
                table: "Niveaus");

            migrationBuilder.DropColumn(
                name: "Annee",
                table: "NatureUniteEnseignements");

            migrationBuilder.DropColumn(
                name: "Annee",
                table: "Mentions");

            migrationBuilder.DropColumn(
                name: "Annee",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "Annee",
                table: "Grades");

            migrationBuilder.DropColumn(
                name: "Annee",
                table: "Formations");

            migrationBuilder.DropColumn(
                name: "Annee",
                table: "Facultes");

            migrationBuilder.DropColumn(
                name: "Annee",
                table: "ElementConstitutifs");

            migrationBuilder.DropColumn(
                name: "FormationId",
                table: "ElementConstitutifs");

            migrationBuilder.DropColumn(
                name: "Annee",
                table: "Domaines");

            migrationBuilder.DropColumn(
                name: "Annee",
                table: "Departements");

            migrationBuilder.DropColumn(
                name: "Annee",
                table: "Debouches");

            migrationBuilder.DropColumn(
                name: "Annee",
                table: "AtomePedagogiques");

            migrationBuilder.DropColumn(
                name: "Annee",
                table: "AtomeElementConstitutifs");

            migrationBuilder.DropColumn(
                name: "FormationId",
                table: "AtomeElementConstitutifs");

            migrationBuilder.AddColumn<int>(
                name: "AnneeDebut",
                table: "Formations",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AnneeFin",
                table: "Formations",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "UniteEnseignementId",
                table: "ElementConstitutifs",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "FormationId",
                table: "Debouches",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ElementConstitutifId",
                table: "AtomeElementConstitutifs",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "AtomePedagogiqueId",
                table: "AtomeElementConstitutifs",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Debouches_FormationId",
                table: "Debouches",
                column: "FormationId");

            migrationBuilder.AddForeignKey(
                name: "FK_AtomeElementConstitutif_AtomePedagogique",
                table: "AtomeElementConstitutifs",
                column: "AtomePedagogiqueId",
                principalTable: "AtomePedagogiques",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AtomeElementConstitutif_ElementConstitutif",
                table: "AtomeElementConstitutifs",
                column: "ElementConstitutifId",
                principalTable: "ElementConstitutifs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Debouche_Formation",
                table: "Debouches",
                column: "FormationId",
                principalTable: "Formations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ElementConstitutif_UniteEnseignement",
                table: "ElementConstitutifs",
                column: "UniteEnseignementId",
                principalTable: "UniteEnseignements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
