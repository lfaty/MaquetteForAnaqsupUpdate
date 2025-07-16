using MaquetteForAnaqsup.API.Base;
using MaquetteForAnaqsup.API.Models.Domain;

namespace MaquetteForAnaqsup.API.Models.DTO
{
    public class DepartementDto
    {
        public Guid Id { get; set; }
        public string? CodeDepartement { get; set; }
        public string? LibelleDepartement { get; set; }
        public Guid? FaculteId { get; set; }
        public string? CodeUniv { get; set; }
        public DateTime? CreateDate { get; set; } 
        public DateTime? UpdateDate { get; set; }
        public virtual FaculteDto Faculte { get; set; }

        // Navigation properties for related entities can be added here if needed
        public virtual ICollection<FormationDto> Formations { get; set; } = new HashSet<FormationDto>();

    }
}