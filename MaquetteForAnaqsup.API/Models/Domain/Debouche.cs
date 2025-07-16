using MaquetteForAnaqsup.API.Base;

namespace MaquetteForAnaqsup.API.Models.Domain
{
    public class Debouche: IEntityBase
    {
        public Guid Id { get; set; }
        public string? LibelleDebouche { get; set; }
        public string? Description { get; set; }
        public Guid? FormationId { get; set; }
        public string? CodeUniv { get; set; }
        public DateTime? CreateDate { get; set; } = DateTime.UtcNow;
        public DateTime? UpdateDate { get; set; }

        public virtual Formation Formation { get; set; }
    }
}
