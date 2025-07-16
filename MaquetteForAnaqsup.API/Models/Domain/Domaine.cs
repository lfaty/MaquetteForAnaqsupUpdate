using MaquetteForAnaqsup.API.Base;

namespace MaquetteForAnaqsup.API.Models.Domain
{
    public class Domaine : IEntityBase
    {  
        public Guid Id { get; set; }
        public string? CodeDomaine { get; set; }
        public string? LibelleDomaine { get; set; }
        public string? CodeUniv { get; set; }

        public DateTime? CreateDate { get; set; } = DateTime.UtcNow;
        public DateTime? UpdateDate { get; set; }

        public virtual ICollection<Mention> Mentions { get; set; } = new HashSet<Mention>();
    }
}
