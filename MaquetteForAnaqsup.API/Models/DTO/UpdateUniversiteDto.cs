using MaquetteForAnaqsup.API.Base;

namespace MaquetteForAnaqsup.API.Models.DTO
{
    public class UpdateUniversiteDto
    {
        public Guid Id { get; set; }
        public string? CodeUniv { get; set; }
        public string? NomUniversite { get; set; }
        public string? SloganUniversite { get; set; }
        public string? AdresseUniversite { get; set; }
        public string? UrlLogo { get; set; }
    }
}
