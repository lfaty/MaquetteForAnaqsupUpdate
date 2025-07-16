namespace MaquetteForAnaqsup.UI.Models.DTO
{
    public class DomaineDto
    {
        public Guid Id { get; set; }
        public string? CodeDomaine { get; set; }
        public string? LibelleDomaine { get; set; }
        public string? CodeUniv { get; set; }

        public DateTime? CreateDate { get; set; } 
        public DateTime? UpdateDate { get; set; }

        public virtual ICollection<MentionDto> Mentions { get; set; } = new HashSet<MentionDto>();
    }
}
