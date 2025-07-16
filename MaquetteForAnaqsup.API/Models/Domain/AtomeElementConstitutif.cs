using MaquetteForAnaqsup.API.Base;

namespace MaquetteForAnaqsup.API.Models.Domain
{
    public class AtomeElementConstitutif : IEntityBase
    {  
        public Guid Id { get; set; }
        public int? VolumeHoraire { get; set; } = 0;
        
        public Guid ElementConstitutifId { get; set; }
        public Guid AtomePedagogiqueId { get; set; }
        public string? CodeUniv { get; set; }

        public DateTime? CreateDate { get; set; } = DateTime.UtcNow;
        public DateTime? UpdateDate { get; set; }

        public virtual ElementConstitutif ElementConstitutif { get; set; }
        public virtual AtomePedagogique AtomePedagogique { get; set; }
        
    }
}
