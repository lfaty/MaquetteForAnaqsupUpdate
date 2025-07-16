using MaquetteForAnaqsup.API.Base;

namespace MaquetteForAnaqsup.API.Models.Domain
{
    public class Niveau : IEntityBase
    {
        public Guid Id { get; set; }
        public int? NumNiveau { get; set; }
        public string? CodeUniv { get; set; }
        public DateTime DateCreation { get; set; } = DateTime.Now;
        public DateTime DateUpdate { get; set; }


        public virtual ICollection<Parcour> Parcours { get; set; } = new HashSet<Parcour>();
    }
}
