namespace MaquetteForAnaqsup.UI.Models.DTO
{
    public class ElementConstitutifDto
    {
        public Guid Id { get; set; }
        public string? CodeEC { get; set; }
        public string? LibelleEC { get; set; }
        public int? CoefEC { get; set; }
        public Guid UniteEnseignementId { get; set; }
        public string? CodeUniv { get; set; }

        public DateTime? CreateDate { get; set; } 
        public DateTime? UpdateDate { get; set; }

        public virtual UniteEnseignementDto UniteEnseignement { get; set; }

        public virtual ICollection<AtomeElementConstitutifDto> AtomeElementConstitutifs { get; set; } = new HashSet<AtomeElementConstitutifDto>();

    }
}
