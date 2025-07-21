using MaquetteForAnaqsup.API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace MaquetteForAnaqsup.API.Data
{
    public class ApplicationsDbContext : DbContext
    {
        public ApplicationsDbContext(DbContextOptions<ApplicationsDbContext> options) : base(options)
        {
        }
        public virtual DbSet<ImportData> ImportDatas { get; set; }
        public virtual DbSet<AtomeElementConstitutif> AtomeElementConstitutifs { get; set; }
        public virtual DbSet<AtomePedagogique> AtomePedagogiques { get; set; }
        public virtual DbSet<NatureUniteEnseignement> NatureUniteEnseignements { get; set; }
        public virtual DbSet<Debouche> Debouches { get; set; }
        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<Grade> Grades { get; set; }
        public virtual DbSet<Niveau> Niveaus { get; set; }
        public virtual DbSet<Semestre> Semestres { get; set; }
        public virtual DbSet<ParcourUniteEnseignement> ParcourUniteEnseignements { get; set; }

        public virtual DbSet<Faculte> Facultes { get; set; }
        public virtual DbSet<Departement> Departements { get; set; }
        public virtual DbSet<Domaine> Domaines { get; set; }
        public virtual DbSet<ElementConstitutif> ElementConstitutifs { get; set; }
        public virtual DbSet<Formation> Formations { get; set; }
        public virtual DbSet<Mention> Mentions { get; set; }
        public virtual DbSet<Parcour> Parcours { get; set; }
        public virtual DbSet<Specialite> Specialites { get; set; }
        public virtual DbSet<UniteEnseignement> UniteEnseignements { get; set; }
        public virtual DbSet<Universite> Universites { get; set; }
        public virtual DbSet<Ville> Villes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ImportData>(entity =>
            {
                entity.Property(e => e.CoefEC)
                      .HasPrecision(18, 6); // Sets precision=18, scale=6 (adjust as needed)
            });

            modelBuilder.Entity<AtomeElementConstitutif>(entity =>
            {
                entity.HasOne(d => d.ElementConstitutif)
                    .WithMany(p => p.AtomeElementConstitutifs)
                    .HasForeignKey(d => d.ElementConstitutifId)
                    .HasConstraintName("FK_AtomeElementConstitutif_ElementConstitutif");

                entity.HasOne(d => d.AtomePedagogique)
                    .WithMany(p => p.AtomeElementConstitutifs)
                    .HasForeignKey(d => d.AtomePedagogiqueId)
                    .HasConstraintName("FK_AtomeElementConstitutif_AtomePedagogique");
            });

            modelBuilder.Entity<ParcourUniteEnseignement>(entity =>
            {
                entity.HasOne(d => d.Parcour)
                    .WithMany(p => p.ParcourUniteEnseignements)
                    .HasForeignKey(d => d.ParcourId)
                    .HasConstraintName("FK_ParcourUniteEnseignement_Parcour");

                entity.HasOne(d => d.UniteEnseignement)
                    .WithMany(p => p.ParcourUniteEnseignements)
                    .HasForeignKey(d => d.UniteEnseignementId)
                    .HasConstraintName("FK_ParcourUniteEnseignement_UniteEnseignement");
            });

            modelBuilder.Entity<Debouche>(entity =>
            {
                entity.HasOne(d => d.Formation)
                    .WithMany(p => p.Debouches)
                    .HasForeignKey(d => d.FormationId)
                    .HasConstraintName("FK_Debouche_Formation");
            });

            modelBuilder.Entity<Departement>(entity =>
            {
                entity.HasOne(d => d.Faculte)
                    .WithMany(p => p.Departements)
                    .HasForeignKey(d => d.FaculteId)
                    .HasConstraintName("FK_Departement_Faculte");
            });


            modelBuilder.Entity<ElementConstitutif>(entity =>
            {
                entity.HasOne(d => d.UniteEnseignement)
                    .WithMany(p => p.ElementConstitutifs)
                    .HasForeignKey(d => d.UniteEnseignementId)
                    .HasConstraintName("FK_ElementConstitutif_UniteEnseignement");
            });

            modelBuilder.Entity<Formation>(entity =>
            {
                entity.HasOne(d => d.Mention)
                    .WithMany(p => p.Formations)
                    .HasForeignKey(d => d.MentionId)
                    .HasConstraintName("FK_Formation_Mention");

                entity.HasOne(d => d.Specialite)
                    .WithMany(p => p.Formations)
                    .HasForeignKey(d => d.SpecialiteId)
                    .HasConstraintName("FK_Formation_Specialite");

                entity.HasOne(d => d.Departement)
                    .WithMany(p => p.Formations)
                    .HasForeignKey(d => d.DepartementId)
                    .HasConstraintName("FK_Formation_Departement");

                entity.HasOne(d => d.Grade)
                    .WithMany(p => p.Formations)
                    .HasForeignKey(d => d.GradeId)
                    .HasConstraintName("FK_Formation_Grade");
            });

            modelBuilder.Entity<Mention>(entity =>
            {
                entity.HasOne(d => d.Domaine)
                    .WithMany(p => p.Mentions)
                    .HasForeignKey(d => d.DomaineId)
                    .HasConstraintName("FK_Mention_Domaine");
            });

            modelBuilder.Entity<Parcour>(entity =>
            {
                entity.HasOne(d => d.Formation)
                    .WithMany(p => p.Parcours)
                    .HasForeignKey(d => d.FormationId)
                    .HasConstraintName("FK_Parcour_Formation");

                entity.HasOne(d => d.Niveau)
                    .WithMany(p => p.Parcours)
                    .HasForeignKey(d => d.NiveauId)
                    .HasConstraintName("FK_Parcour_Niveau");

                entity.HasOne(d => d.Semestre)
                    .WithMany(p => p.Parcours)
                    .HasForeignKey(d => d.SemestreId)
                    .HasConstraintName("FK_Parcour_Semestre");
            });

            modelBuilder.Entity<Specialite>(entity =>
            {
                entity.HasOne(d => d.Mention)
                    .WithMany(p => p.Specialites)
                    .HasForeignKey(d => d.MentionId)
                    .HasConstraintName("FK_Specialite_Mention");
            });

            modelBuilder.Entity<UniteEnseignement>(entity =>
            {
                entity.HasOne(d => d.NatureUniteEnseignement)
                    .WithMany(p => p.UniteEnseignements)
                    .HasForeignKey(d => d.NatureUniteEnseignementId)
                    .HasConstraintName("FK_UniteEnseignement_NatureUniteEnseignement");
            });

            //modelBuilder.Entity<Universite>(entity =>
            //{
            //    entity.HasOne(d => d.Ville)
            //        .WithMany(p => p.Universites)
            //        .HasForeignKey(d => d.VilleId)
            //        .HasConstraintName("FK_Universite_Ville");
            //});
        }
    }
}
