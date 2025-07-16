using MaquetteForAnaqsup.API.Base;

namespace MaquetteForAnaqsup.API.Models.Domain
{
    public class Formation : IEntityBase
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
        public DateTime? CreateDate { get; set; } = DateTime.UtcNow;
        public DateTime? UpdateDate { get; set; }

        public virtual Mention? Mention { get; set; }
        public virtual Specialite? Specialite { get; set; }
        public virtual Departement? Departement { get; set; }
        public virtual Grade? Grade { get; set; }

        // Navigation properties
        public virtual ICollection<Debouche> Debouches { get; set; } = new HashSet<Debouche>();
        public virtual ICollection<Parcour> Parcours { get; set; } = new HashSet<Parcour>();

    }
}
