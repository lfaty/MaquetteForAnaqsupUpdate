using MaquetteForAnaqsup.API.Models.Domain;

namespace MaquetteForAnaqsup.API.Models.DTO
{
    public class SpecialiteDto
    {
        public Guid Id { get; set; }
        public string? CodeSpecialite { get; set; }
        public string? LibelleSpecialite { get; set; }
        public Guid? MentionId { get; set; }
        public string? CodeUniv { get; set; }

        public DateTime DateCreation { get; set; } 
        public DateTime DateUpdate { get; set; }
        // Navigation properties
        public virtual MentionDto? Mention { get; set; }

        public virtual ICollection<FormationDto> Formations { get; set; } = new HashSet<FormationDto>();
    }
}
