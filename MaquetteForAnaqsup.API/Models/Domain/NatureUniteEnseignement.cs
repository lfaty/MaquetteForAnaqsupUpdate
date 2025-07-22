using MaquetteForAnaqsup.API.Base;

namespace MaquetteForAnaqsup.API.Models.Domain
{
    public class NatureUniteEnseignement : IEntityBase
    {
        public Guid Id { get; set; }
        public string? LibelleNature { get; set; }
        public string? CodeUniv { get; set; }
        public string? Annee { get; set; }
        public DateTime DateCreation { get; set; } = DateTime.Now;
        public DateTime DateUpdate { get; set; }


        public virtual ICollection<UniteEnseignement> UniteEnseignements { get; set; } = new HashSet<UniteEnseignement>();
    }
}
