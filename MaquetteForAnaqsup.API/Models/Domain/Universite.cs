using MaquetteForAnaqsup.API.Base;

namespace MaquetteForAnaqsup.API.Models.Domain
{
    public class Universite : IEntityBase
    {
        public Guid Id { get; set; }
        public string? CodeUniv { get; set; }
        public string? Annee { get; set; }
        public string? NomUniversite { get; set; }
        public string? SloganUniversite { get; set; }
        public string? AdresseUniversite { get; set; }
        public string? UrlLogo { get; set; }
        //public Guid VilleId { get; set; }
        public DateTime DateCreation { get; set; } = DateTime.Now;
        public DateTime DateUpdate { get; set; }

        //public virtual Ville? Ville { get; set; }
    }
}
