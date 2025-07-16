namespace MaquetteForAnaqsup.UI.Models.DTO
{
    public class MentionDto
    {
        public Guid Id { get; set; }
        public string? CodeMention { get; set; }
        public string? LibelleMention { get; set; }
        public Guid? DomaineId { get; set; }
        public string? CodeUniv { get; set; }

        public DateTime DateCreation { get; set; } 
        public DateTime DateUpdate { get; set; }

        public virtual DomaineDto? Domaine { get; set; }
        // Navigation properties
        public virtual ICollection<SpecialiteDto> Specialites { get; set; } = new HashSet<SpecialiteDto>();
        public virtual ICollection<FormationDto> Formations { get; set; } = new HashSet<FormationDto>();
    }
}
