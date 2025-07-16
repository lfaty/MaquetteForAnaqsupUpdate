namespace MaquetteForAnaqsup.UI.Models.DTO
{
    public class UniteEnseignementDto
    {
        public Guid Id { get; set; }
        public string? CodeUE { get; set; }
        public string? LibelleUE { get; set; }
        public string? NatureUE { get; set; }
        public int? CreditUE { get; set; }
        public int? CoefUE { get; set; }
        public string? CodeUniv { get; set; }

        public DateTime? CreateDate { get; set; } 
        public DateTime? UpdateDate { get; set; }

        public virtual ICollection<ElementConstitutifDto> ElementConstitutifs { get; set; } = new HashSet<ElementConstitutifDto>();
        public virtual ICollection<ParcourUniteEnseignementDto> ParcourUniteEnseignements { get; set; } = new HashSet<ParcourUniteEnseignementDto>();
    }
}
