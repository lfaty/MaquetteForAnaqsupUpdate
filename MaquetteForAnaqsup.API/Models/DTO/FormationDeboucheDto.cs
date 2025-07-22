using MaquetteForAnaqsup.API.Base;

namespace MaquetteForAnaqsup.API.Models.DTO
{
    public class FormationDeboucheDto : IEntityBase
    {
        public Guid Id { get; set; }
        public Guid? FormationId { get; set; }
        public Guid DeboucheId { get; set; }
        public string? CodeUniv { get; set; }
        public string? Annee { get; set; }
        public DateTime? CreateDate { get; set; } = DateTime.UtcNow;
        public DateTime? UpdateDate { get; set; }

        public virtual FormationDto Formation { get; set; }
        public virtual DeboucheDto Debouche { get; set; }
    }
}
