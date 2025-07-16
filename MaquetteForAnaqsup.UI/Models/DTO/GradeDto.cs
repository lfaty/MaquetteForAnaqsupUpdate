namespace MaquetteForAnaqsup.UI.Models.DTO
{
    public class GradeDto
    {
        public Guid Id { get; set; }
        public string? LibelleGrade { get; set; }
        public string? CodeUniv { get; set; }
        public DateTime DateCreation { get; set; } 
        public DateTime DateUpdate { get; set; }


        public virtual ICollection<FormationDto> Formations { get; set; } = new HashSet<FormationDto>();
    }
}
