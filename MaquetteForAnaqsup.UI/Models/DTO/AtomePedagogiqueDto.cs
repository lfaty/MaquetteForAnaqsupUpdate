namespace MaquetteForAnaqsup.UI.Models.DTO
{
    public class AtomePedagogiqueDto
    {
        public Guid Id { get; set; }
        public string? LibelleAtomePedagogique { get; set; }
        public string? CodeUniv { get; set; }

        public DateTime? CreateDate { get; set; } 
        public DateTime? UpdateDate { get; set; }

        public virtual ICollection<AtomeElementConstitutifDto> AtomeElementConstitutifs { get; set; } = new HashSet<AtomeElementConstitutifDto>();
    }
}
