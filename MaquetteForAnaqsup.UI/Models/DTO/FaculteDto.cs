
namespace MaquetteForAnaqsup.UI.Models.DTO
{
    public class FaculteDto
    {
        public Guid Id { get; set; }
        public string? CodeFaculte { get; set; }
        public string? LibelleFaculte { get; set; }
        public string? CodeUniv { get; set; }

        public DateTime? CreateDate { get; set; } 
        public DateTime? UpdateDate { get; set; }

        public virtual ICollection<DepartementDto> Departements { get; set; } = new HashSet<DepartementDto>();
    }
}
