using MaquetteForAnaqsup.API.Enum;

namespace MaquetteForAnaqsup.API.Models.DTO
{
    public partial class AnneeMaquetteDto
    {
        public Guid Id { get; set; }
        public string? Libelle { get; set; }
        public DateTime? CreateDate { get; set; } 
        public DateTime? UpdateDate { get; set; }
        public string? Annee { get; set; }
        public string? Struct { get; set; }
        public Statut Statut { get; set; }
        public DateTime? DateStatut { get; set; }
    }
}
