namespace MaquetteForAnaqsup.UI.Models.DTO
{
    public class ParcourUniteEnseignementDto
    {
        public Guid Id { get; set; }
        public string? CodeUniv { get; set; }
        public Guid? UniteEnseignementId { get; set; }
        public Guid? ParcourId { get; set; }
        public DateTime? CreateDate { get; set; } 
        public DateTime? UpdateDate { get; set; }
        public virtual UniteEnseignementDto UniteEnseignement { get; set; }
        public virtual ParcourDto Parcour { get; set; }
    }
}