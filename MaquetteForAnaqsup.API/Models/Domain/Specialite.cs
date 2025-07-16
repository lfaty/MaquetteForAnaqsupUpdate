using MaquetteForAnaqsup.API.Base;

namespace MaquetteForAnaqsup.API.Models.Domain
{
    public class Specialite : IEntityBase
    {
        public Guid Id { get; set; }
        public string? CodeSpecialite { get; set; }
        public string? LibelleSpecialite { get; set; }
        public Guid? MentionId { get; set; }
        public string? CodeUniv { get; set; }

        public DateTime DateCreation { get; set; } = DateTime.Now;
        public DateTime DateUpdate { get; set; }
        // Navigation properties
        public virtual Mention? Mention { get; set; }

        public virtual ICollection<Formation> Formations { get; set; } = new HashSet<Formation>();
    }
}
