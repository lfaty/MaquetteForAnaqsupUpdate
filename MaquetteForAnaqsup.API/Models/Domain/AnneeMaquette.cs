using MaquetteForAnaqsup.API.Base;
using MaquetteForAnaqsup.API.Enum;
using System.ComponentModel.DataAnnotations;

namespace MaquetteForAnaqsup.API.Models.Domain
{
    public partial class AnneeMaquette : IEntityBase
    {
        [Key]
        public Guid Id { get; set; }
        public string? Libelle { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.UtcNow;
        public DateTime? UpdateDate { get; set; }
        public string? Annee { get; set; }
        public string? Struct { get; set; }
        public Statut Statut { get; set; } = Statut.NonValide;
        public DateTime? DateStatut { get; set; }
        public string? CodeUniv { get; set; }
    }
}
