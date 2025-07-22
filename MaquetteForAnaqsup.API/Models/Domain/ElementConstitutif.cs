using MaquetteForAnaqsup.API.Base;

namespace MaquetteForAnaqsup.API.Models.Domain
{
    public class ElementConstitutif : IEntityBase
    {  
        public Guid Id { get; set; }
        public string? CodeEC { get; set; }
        public string? LibelleEC { get; set; }
        public int? CoefEC { get; set; }
        public Guid? UniteEnseignementId { get; set; }
        public Guid? FormationId { get; set; }
        public string? CodeUniv { get; set; }
        public string? Annee { get; set; }
        public DateTime? CreateDate { get; set; } = DateTime.UtcNow;
        public DateTime? UpdateDate { get; set; }

        public virtual UniteEnseignement UniteEnseignement { get; set; }
        public virtual Formation Formation { get; set; }

        public virtual ICollection<AtomeElementConstitutif> AtomeElementConstitutifs { get; set; } = new HashSet<AtomeElementConstitutif>();
    }
}
