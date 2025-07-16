using MaquetteForAnaqsup.API.Models.Domain;

namespace MaquetteForAnaqsup.API.Models.DTO
{
    public class AtomeElementConstitutifDto
    {
        public Guid Id { get; set; }
        public int? VolumeHoraire { get; set; } = 0;

        public Guid ElementConstitutifId { get; set; }
        public Guid AtomePedagogiqueId { get; set; }
        public string? CodeUniv { get; set; }

        public DateTime? CreateDate { get; set; } 
        public DateTime? UpdateDate { get; set; }

        public virtual ElementConstitutifDto ElementConstitutif { get; set; }
        public virtual AtomePedagogiqueDto AtomePedagogique { get; set; }
    }
}
