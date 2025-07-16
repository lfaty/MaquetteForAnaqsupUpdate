namespace MaquetteForAnaqsup.UI.Models.DTO
{
    public class DataElementConstitutifDto
    {
        public string CodeUniversite { get; set; }
        public string Faculte { get; set; }
        public string Departement { get; set; }
        public string Abreviation { get; set; }
        public string LibelleFormation { get; set; }
        public string Grade { get; set; }
        public string LibelleParcour { get; set; }
        public int Niveau { get; set; }
        public int TotalVolumeHoraire { get; set; }
        public string? CodeUE { get; set; }
        public string? LibelleUE { get; set; }
        public int? CreditUE { get; set; }
        public int? CoefUE { get; set; }
        public string? NatureUE { get; set; }
        public int? Semestre { get; set; }
        public string? LibelleLongEC { get; set; }
        public decimal? CoefEC { get; set; }
        public int? VolumeHoraire { get; set; }
    }
}
