using MaquetteForAnaqsup.API.Base;

namespace MaquetteForAnaqsup.API.Models.Domain
{
    public class Departement : IEntityBase
    {
        public Guid Id { get; set; }
        public string? CodeDepartement { get; set; }
        public string? LibelleDepartement { get; set; }
        public Guid? FaculteId { get; set; }
        public string? CodeUniv { get; set; }
        public DateTime? CreateDate { get; set; } = DateTime.UtcNow;
        public DateTime? UpdateDate { get; set; }
        public virtual Faculte Faculte { get; set; }

        // Navigation properties for related entities can be added here if needed
        public virtual ICollection<Formation> Formations { get; set; } = new HashSet<Formation>();
    }
}