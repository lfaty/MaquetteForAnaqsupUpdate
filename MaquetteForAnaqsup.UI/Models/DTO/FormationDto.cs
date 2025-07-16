namespace MaquetteForAnaqsup.UI.Models.DTO
{
    public class FormationDto
    {
        public Guid Id { get; set; }
        public string? CodeFormation { get; set; }
        public string? LibelleFormation { get; set; }
        public string? CodeUniv { get; set; }
        public Guid? MentionId { get; set; }
        public Guid? SpecialiteId { get; set; }
        public Guid? DepartementId { get; set; }
        public Guid? GradeId { get; set; }
        public int? AnneeDebut { get; set; }
        public int? AnneeFin { get; set; }
        public DateTime? CreateDate { get; set; } 
        public DateTime? UpdateDate { get; set; }

        public virtual MentionDto? Mention { get; set; }
        public virtual SpecialiteDto? Specialite { get; set; }
        public virtual DepartementDto? Departement { get; set; }
        public virtual GradeDto? Grade { get; set; }

        // Navigation properties
        public virtual ICollection<DeboucheDto> Debouches { get; set; } = new HashSet<DeboucheDto>();
        public virtual ICollection<ParcourDto> Parcours { get; set; } = new HashSet<ParcourDto>();

    }
}
