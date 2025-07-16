using MaquetteForAnaqsup.API.Base;
using Microsoft.VisualBasic;

namespace MaquetteForAnaqsup.API.Models.Domain
{
    public class Mention : IEntityBase
    {
        public Guid Id { get; set; }
        public string? CodeMention { get; set; }
        public string? LibelleMention { get; set; }
        public Guid? DomaineId { get; set; }
        public string? CodeUniv { get; set; }

        public DateTime DateCreation { get; set; } = DateTime.Now;
        public DateTime DateUpdate { get; set; }

        public virtual Domaine? Domaine { get; set; }
        // Navigation properties
        public virtual ICollection<Specialite> Specialites { get; set; } = new HashSet<Specialite>();
        public virtual ICollection<Formation> Formations { get; set; } = new HashSet<Formation>();
    }
}
