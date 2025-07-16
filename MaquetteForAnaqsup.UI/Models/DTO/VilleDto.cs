namespace MaquetteForAnaqsup.UI.Models.DTO
{
    public class VilleDto 
    {
        public Guid Id { get; set; }
        public string? CodeVille { get; set; }
        public string? NomVille { get; set; }
        public string? CodeUniv { get; set; }
        public DateTime DateCreation { get; set; }
        public DateTime DateUpdate { get; set; }


        public virtual ICollection<UniversiteDto> Universites { get; set; } = new HashSet<UniversiteDto>();
    }
}
