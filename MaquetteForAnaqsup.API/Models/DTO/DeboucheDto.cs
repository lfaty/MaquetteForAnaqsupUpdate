using MaquetteForAnaqsup.API.Base;
using MaquetteForAnaqsup.API.Models.Domain;

namespace MaquetteForAnaqsup.API.Models.DTO
{
    public class DeboucheDto
    {
        public Guid Id { get; set; }
        public string? LibelleDebouche { get; set; }
        public string? Description { get; set; }
        public Guid? FormationId { get; set; }
        public string? CodeUniv { get; set; }
        public DateTime? CreateDate { get; set; } 
        public DateTime? UpdateDate { get; set; }

        public virtual FormationDto Formation { get; set; }
    }
}
