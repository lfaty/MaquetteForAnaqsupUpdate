using MaquetteForAnaqsup.API.Base;

namespace MaquetteForAnaqsup.API.Models.Domain
{
    public class UniteEnseignement : IEntityBase
    {  
        public Guid Id { get; set; }
        public string? CodeUE { get; set; }
        public string? LibelleUE { get; set; }
        public Guid? NatureUniteEnseignementId { get; set; }
        public Guid? FormationId { get; set; }
        public int? CreditUE { get; set; }
        public int? CoefUE { get; set; }
        public string? CodeUniv { get; set; }
        public string? Annee { get; set; }
        public DateTime? CreateDate { get; set; } = DateTime.UtcNow;
        public DateTime? UpdateDate { get; set; }

        public NatureUniteEnseignement? NatureUniteEnseignement { get; set; }
        public Formation? Formation { get; set; }

        public virtual ICollection<ElementConstitutif> ElementConstitutifs { get; set; } = new HashSet<ElementConstitutif>();
        public virtual ICollection<ParcourUniteEnseignement> ParcourUniteEnseignements { get; set; } = new HashSet<ParcourUniteEnseignement>();
    }
}
