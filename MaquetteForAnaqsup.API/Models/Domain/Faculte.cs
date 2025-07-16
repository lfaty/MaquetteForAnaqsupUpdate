using MaquetteForAnaqsup.API.Base;

namespace MaquetteForAnaqsup.API.Models.Domain
{
    public class Faculte : IEntityBase
    {  
        public Guid Id { get; set; }
        public string? CodeFaculte { get; set; }
        public string? LibelleFaculte { get; set; }
        public string? CodeUniv { get; set; }

        public DateTime? CreateDate { get; set; } = DateTime.UtcNow;
        public DateTime? UpdateDate { get; set; }

        public virtual ICollection<Departement> Departements { get; set; } = new HashSet<Departement>();
    }
}
