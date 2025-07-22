using MaquetteForAnaqsup.API.Base;

namespace MaquetteForAnaqsup.API.Models.Domain
{
    public class Ville : IEntityBase
    {
        public Guid Id { get; set; }
        public string? CodeVille { get; set; }
        public string? NomVille { get; set; }
        public string? CodeUniv { get; set; }
        public string? Annee { get; set; }
        public DateTime DateCreation { get; set; } = DateTime.Now;
        public DateTime DateUpdate { get; set; }


        public virtual ICollection<Universite> Universites { get; set; } = new HashSet<Universite>();
    }
}
