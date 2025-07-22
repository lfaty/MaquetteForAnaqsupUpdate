using MaquetteForAnaqsup.API.Base;
using MaquetteForAnaqsup.API.Enum;

namespace MaquetteForAnaqsup.API.Models.Domain
{
    public class UniversiteUser : IEntityBase
    {
        public Guid Id { get; set; }
        public string? UniversiteId { get; set; }
        public string? UserId { get; set; }
        public string? RoleId { get; set; }
        public Statut Statut { get; set; } = Statut.NonValide;
        public DateTime? DateStatut { get; set; }
        public DateTime? CreateDate { get; set; } = DateTime.UtcNow;
        public DateTime? UpdateDate { get; set; }
        public string? Annee { get; set; }
        public string? CodeUniv { get; set; }
    }
}
