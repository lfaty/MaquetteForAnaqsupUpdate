using MaquetteForAnaqsup.API.Base;

namespace MaquetteForAnaqsup.API.Models.Domain
{
    public class ParcourUniteEnseignement : IEntityBase
    {
        public Guid Id { get; set; }
        public string? CodeUniv { get; set; }
        public Guid? UniteEnseignementId { get; set; }
        public Guid? ParcourId { get; set; }
        public DateTime? CreateDate { get; set; } = DateTime.UtcNow;
        public DateTime? UpdateDate { get; set; }
        public virtual UniteEnseignement UniteEnseignement { get; set; }
        public virtual Parcour Parcour { get; set; }
    }
}