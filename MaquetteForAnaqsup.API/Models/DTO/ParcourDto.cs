
using MaquetteForAnaqsup.API.Models.Domain;

namespace MaquetteForAnaqsup.API.Models.DTO
{
    public class ParcourDto
    {
        public Guid Id { get; set; }
        public string? CodeParcour { get; set; }
        public string? LibelleParcour { get; set; }
        public string? Description { get; set; }
        public Guid? FormationId { get; set; }
        public string? CodeUniv { get; set; }
        public Guid? SemestreId { get; set; }
        public Guid NiveauId { get; set; }
        public DateTime? CreateDate { get; set; } = DateTime.UtcNow;
        public DateTime? UpdateDate { get; set; }

        public virtual FormationDto Formation { get; set; }
        public virtual SemestreDto Semestre { get; set; }
        public virtual NiveauDto Niveau { get; set; }

        public virtual ICollection<ParcourUniteEnseignementDto> ParcourUniteEnseignements { get; set; } = new HashSet<ParcourUniteEnseignementDto>();
    }
}
