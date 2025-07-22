using MaquetteForAnaqsup.API.Base;

namespace MaquetteForAnaqsup.API.Models.Domain
{
    public class Parcour : IEntityBase
    {
        public Guid Id { get; set; }
        public string? CodeParcour { get; set; }
        public string? LibelleParcour { get; set; }
        public string? Description { get; set; }
        public Guid? FormationId { get; set; }
        public string? CodeUniv { get; set; }
        public string? Annee { get; set; }
        public Guid? SemestreId { get; set; }
        public Guid NiveauId { get; set; }
        public DateTime? CreateDate { get; set; } = DateTime.UtcNow;
        public DateTime? UpdateDate { get; set; }

        public virtual Formation Formation { get; set; }
        public virtual Semestre Semestre { get; set; }
        public virtual Niveau Niveau { get; set; }

        public virtual ICollection<ParcourUniteEnseignement> ParcourUniteEnseignements { get; set; } = new HashSet<ParcourUniteEnseignement>();
    }
}
