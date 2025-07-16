namespace MaquetteForAnaqsup.UI.Models.DTO
{
    public class DataStatComparaisonDto
    {
        public string? CodeUniversite { get; set; }
        public string? Abreviation { get; set; }
        public string? LibelleFormation { get; set; }

        public string? Grade { get; set; }

        public int? Semestre { get; set; }

        public string? Parcours { get; set; }

        public int? Niveau { get; set; }

        public string? CodeUE { get; set; }

        public string? LibelleUE { get; set; }
        public int? CreditUE { get; set; }

        public int? CoefUE { get; set; }
        public string? NatureUE { get; set; }
        public string? CodeEC { get; set; }

        public string? LibelleLongEC { get; set; }
        public decimal? CoefEC { get; set; }
        public int? VolumeHoraire { get; set; }

    }
}
