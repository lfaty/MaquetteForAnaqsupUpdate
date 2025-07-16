using MaquetteForAnaqsup.API.Base;

namespace MaquetteForAnaqsup.API.Models.Domain
{
    public class AtomePedagogique : IEntityBase
    {  
        public Guid Id { get; set; }
        public string? LibelleAP { get; set; }
        public string? CodeUniv { get; set; }

        public DateTime? CreateDate { get; set; } = DateTime.UtcNow;
        public DateTime? UpdateDate { get; set; }

        public virtual ICollection<AtomeElementConstitutif> AtomeElementConstitutifs { get; set; } = new HashSet<AtomeElementConstitutif>();

    }
}
