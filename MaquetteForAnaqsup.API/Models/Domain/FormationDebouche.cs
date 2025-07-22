using MaquetteForAnaqsup.API.Base;

namespace MaquetteForAnaqsup.API.Models.Domain
{
    public class FormationDebouche : IEntityBase
    {
        public Guid Id { get; set; }
        public Guid? FormationId { get; set; }
        public Guid DeboucheId { get; set; }
        public string? CodeUniv { get; set; }
        public string? Annee { get; set; }
        public DateTime? CreateDate { get; set; } = DateTime.UtcNow;
        public DateTime? UpdateDate { get; set; }

        public virtual Formation Formation { get; set; }
        public virtual Debouche Debouche { get; set; }
    }
}
