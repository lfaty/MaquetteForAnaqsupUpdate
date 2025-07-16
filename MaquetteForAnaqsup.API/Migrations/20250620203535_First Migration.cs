using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MaquetteForAnaqsup.API.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AtomePedagogiques",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LibelleAP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodeUniv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AtomePedagogiques", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Domaines",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CodeDomaine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LibelleDomaine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodeUniv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Domaines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Facultes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CodeFaculte = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LibelleFaculte = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodeUniv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facultes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Grades",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LibelleGrade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodeUniv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileExtension = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileSizeInBytes = table.Column<long>(type: "bigint", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodeUniv = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ImportDatas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodeUniversite = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LibelleUniversite = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Faculte = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Departement = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodeDomaine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LibelleDomaine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mention = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Specialite = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Abreviation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LibelleFormation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Grade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Semestre = table.Column<int>(type: "int", nullable: true),
                    Parcours = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Niveau = table.Column<int>(type: "int", nullable: true),
                    CodeUE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LibelleUE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreditUE = table.Column<int>(type: "int", nullable: true),
                    CoefUE = table.Column<int>(type: "int", nullable: true),
                    NatureUE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodeEC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LibelleLongEC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CoefEC = table.Column<int>(type: "int", nullable: true),
                    AtomePedagogique = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VolumeHoraire = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImportDatas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NatureUniteEnseignements",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LibelleNature = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodeUniv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NatureUniteEnseignements", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Niveaus",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NumNiveau = table.Column<int>(type: "int", nullable: true),
                    CodeUniv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Niveaus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Semestres",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NumSemestre = table.Column<int>(type: "int", nullable: true),
                    CodeUniv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Semestres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Villes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CodeVille = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NomVille = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodeUniv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Villes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mentions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CodeMention = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LibelleMention = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DomaineId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CodeUniv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mentions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mention_Domaine",
                        column: x => x.DomaineId,
                        principalTable: "Domaines",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Departements",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CodeDepartement = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LibelleDepartement = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FaculteId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CodeUniv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Departement_Faculte",
                        column: x => x.FaculteId,
                        principalTable: "Facultes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UniteEnseignements",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CodeUE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LibelleUE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NatureUniteEnseignementId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreditUE = table.Column<int>(type: "int", nullable: true),
                    CoefUE = table.Column<int>(type: "int", nullable: true),
                    CodeUniv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UniteEnseignements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UniteEnseignement_NatureUniteEnseignement",
                        column: x => x.NatureUniteEnseignementId,
                        principalTable: "NatureUniteEnseignements",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Universites",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CodeUniv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NomUniversite = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SloganUniversite = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdresseUniversite = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UrlLogo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VilleId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Universites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Universites_Villes_VilleId",
                        column: x => x.VilleId,
                        principalTable: "Villes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Specialites",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CodeSpecialite = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LibelleSpecialite = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MentionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CodeUniv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Specialite_Mention",
                        column: x => x.MentionId,
                        principalTable: "Mentions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ElementConstitutifs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CodeEC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LibelleEC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CoefEC = table.Column<int>(type: "int", nullable: true),
                    UniteEnseignementId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CodeUniv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElementConstitutifs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ElementConstitutif_UniteEnseignement",
                        column: x => x.UniteEnseignementId,
                        principalTable: "UniteEnseignements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Formations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CodeFormation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LibelleFormation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodeUniv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MentionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SpecialiteId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DepartementId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    GradeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AnneeDebut = table.Column<int>(type: "int", nullable: true),
                    AnneeFin = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Formations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Formation_Departement",
                        column: x => x.DepartementId,
                        principalTable: "Departements",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Formation_Grade",
                        column: x => x.GradeId,
                        principalTable: "Grades",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Formation_Mention",
                        column: x => x.MentionId,
                        principalTable: "Mentions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Formation_Specialite",
                        column: x => x.SpecialiteId,
                        principalTable: "Specialites",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AtomeElementConstitutifs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VolumeHoraire = table.Column<int>(type: "int", nullable: true),
                    ElementConstitutifId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AtomePedagogiqueId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CodeUniv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AtomeElementConstitutifs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AtomeElementConstitutif_AtomePedagogique",
                        column: x => x.AtomePedagogiqueId,
                        principalTable: "AtomePedagogiques",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AtomeElementConstitutif_ElementConstitutif",
                        column: x => x.ElementConstitutifId,
                        principalTable: "ElementConstitutifs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Debouches",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LibelleDebouche = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FormationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CodeUniv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Debouches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Debouche_Formation",
                        column: x => x.FormationId,
                        principalTable: "Formations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Parcours",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CodeParcour = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LibelleParcour = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FormationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CodeUniv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SemestreId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    NiveauId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parcours", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Parcour_Formation",
                        column: x => x.FormationId,
                        principalTable: "Formations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Parcour_Niveau",
                        column: x => x.NiveauId,
                        principalTable: "Niveaus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Parcour_Semestre",
                        column: x => x.SemestreId,
                        principalTable: "Semestres",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ParcourUniteEnseignements",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CodeUniv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UniteEnseignementId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ParcourId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParcourUniteEnseignements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParcourUniteEnseignement_Parcour",
                        column: x => x.ParcourId,
                        principalTable: "Parcours",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ParcourUniteEnseignement_UniteEnseignement",
                        column: x => x.UniteEnseignementId,
                        principalTable: "UniteEnseignements",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AtomeElementConstitutifs_AtomePedagogiqueId",
                table: "AtomeElementConstitutifs",
                column: "AtomePedagogiqueId");

            migrationBuilder.CreateIndex(
                name: "IX_AtomeElementConstitutifs_ElementConstitutifId",
                table: "AtomeElementConstitutifs",
                column: "ElementConstitutifId");

            migrationBuilder.CreateIndex(
                name: "IX_Debouches_FormationId",
                table: "Debouches",
                column: "FormationId");

            migrationBuilder.CreateIndex(
                name: "IX_Departements_FaculteId",
                table: "Departements",
                column: "FaculteId");

            migrationBuilder.CreateIndex(
                name: "IX_ElementConstitutifs_UniteEnseignementId",
                table: "ElementConstitutifs",
                column: "UniteEnseignementId");

            migrationBuilder.CreateIndex(
                name: "IX_Formations_DepartementId",
                table: "Formations",
                column: "DepartementId");

            migrationBuilder.CreateIndex(
                name: "IX_Formations_GradeId",
                table: "Formations",
                column: "GradeId");

            migrationBuilder.CreateIndex(
                name: "IX_Formations_MentionId",
                table: "Formations",
                column: "MentionId");

            migrationBuilder.CreateIndex(
                name: "IX_Formations_SpecialiteId",
                table: "Formations",
                column: "SpecialiteId");

            migrationBuilder.CreateIndex(
                name: "IX_Mentions_DomaineId",
                table: "Mentions",
                column: "DomaineId");

            migrationBuilder.CreateIndex(
                name: "IX_Parcours_FormationId",
                table: "Parcours",
                column: "FormationId");

            migrationBuilder.CreateIndex(
                name: "IX_Parcours_NiveauId",
                table: "Parcours",
                column: "NiveauId");

            migrationBuilder.CreateIndex(
                name: "IX_Parcours_SemestreId",
                table: "Parcours",
                column: "SemestreId");

            migrationBuilder.CreateIndex(
                name: "IX_ParcourUniteEnseignements_ParcourId",
                table: "ParcourUniteEnseignements",
                column: "ParcourId");

            migrationBuilder.CreateIndex(
                name: "IX_ParcourUniteEnseignements_UniteEnseignementId",
                table: "ParcourUniteEnseignements",
                column: "UniteEnseignementId");

            migrationBuilder.CreateIndex(
                name: "IX_Specialites_MentionId",
                table: "Specialites",
                column: "MentionId");

            migrationBuilder.CreateIndex(
                name: "IX_UniteEnseignements_NatureUniteEnseignementId",
                table: "UniteEnseignements",
                column: "NatureUniteEnseignementId");

            migrationBuilder.CreateIndex(
                name: "IX_Universites_VilleId",
                table: "Universites",
                column: "VilleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AtomeElementConstitutifs");

            migrationBuilder.DropTable(
                name: "Debouches");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "ImportDatas");

            migrationBuilder.DropTable(
                name: "ParcourUniteEnseignements");

            migrationBuilder.DropTable(
                name: "Universites");

            migrationBuilder.DropTable(
                name: "AtomePedagogiques");

            migrationBuilder.DropTable(
                name: "ElementConstitutifs");

            migrationBuilder.DropTable(
                name: "Parcours");

            migrationBuilder.DropTable(
                name: "Villes");

            migrationBuilder.DropTable(
                name: "UniteEnseignements");

            migrationBuilder.DropTable(
                name: "Formations");

            migrationBuilder.DropTable(
                name: "Niveaus");

            migrationBuilder.DropTable(
                name: "Semestres");

            migrationBuilder.DropTable(
                name: "NatureUniteEnseignements");

            migrationBuilder.DropTable(
                name: "Departements");

            migrationBuilder.DropTable(
                name: "Grades");

            migrationBuilder.DropTable(
                name: "Specialites");

            migrationBuilder.DropTable(
                name: "Facultes");

            migrationBuilder.DropTable(
                name: "Mentions");

            migrationBuilder.DropTable(
                name: "Domaines");
        }
    }
}
