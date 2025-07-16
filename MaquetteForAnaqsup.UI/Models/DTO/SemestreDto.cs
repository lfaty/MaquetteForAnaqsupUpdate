namespace MaquetteForAnaqsup.UI.Models.DTO
{
    public class SemestreDto
    {
        public Guid Id { get; set; }
        public int? NumSemestre { get; set; }
        public string? CodeUniv { get; set; }
        public DateTime DateCreation { get; set; } 
        public DateTime DateUpdate { get; set; }


        public virtual ICollection<ParcourDto> Parcours { get; set; } = new HashSet<ParcourDto>();
    }
}
