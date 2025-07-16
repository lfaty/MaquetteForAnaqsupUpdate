namespace MaquetteForAnaqsup.API
{
    public class ImportData
    {

        public int Id { get; set; }

        public string? CodeUniversite { get; set; }

        public string? LibelleUniversite { get; set; }

        public string? Faculte { get; set; }

        public string? Departement { get; set; }

        public string? CodeDomaine { get; set; }

        public string? LibelleDomaine { get; set; }

        public string? Mention { get; set; }

        public string? Specialite { get; set; }

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
        public int? CM { get; set; }
        public int? TD { get; set; }
        public int? TP { get; set; }
        public int? SEM { get; set; }
        public int? TPE { get; set; }

    }
}
