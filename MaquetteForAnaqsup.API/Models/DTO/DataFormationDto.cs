namespace MaquetteForAnaqsup.API.Models.DTO
{
    public class DataFormationDto
    {
        public string CodeUniversite { get; set; }
        public string Faculte { get; set; }
        public string Departement { get; set; }
        public string Abreviation { get; set; }
        public string LibelleFormation { get; set; }
        public string Grade { get; set; }
        public int VolumeHoraire { get; set; } // Total Volume Horaire
    }
}
