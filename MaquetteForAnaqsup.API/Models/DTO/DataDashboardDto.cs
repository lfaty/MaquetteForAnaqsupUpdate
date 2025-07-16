using MaquetteForAnaqsup.API.Models.DTO;

namespace MaquetteForAnaqsup.API.Models.DTO
{
    public class DataDashboardDto
    {
        public virtual IEnumerable<ImportDataDto>? ImportDatas { get; set; }
        public virtual IEnumerable<DataUniversiteDto> DataUniversites { get; set; }
        public virtual IEnumerable<DataDepartementDto> DataDepartements { get; set; }
        public virtual IEnumerable<DataGradeDto> DataGrades { get; set; }
        public virtual IEnumerable<DataNiveauDto> DataNiveaus { get; set; }
        public virtual IEnumerable<DataSemestreDto> DataSemestres { get; set; }
        public virtual IEnumerable<DataFormationDto> DataFormations { get; set; }
        public virtual IEnumerable<DataParcourDto> DataParcours { get; set; }
        public virtual IEnumerable<DataUniteEnseignementDto> DataUniteEnseignements { get; set; }
        public virtual IEnumerable<DataElementConstitutifDto> DataElementConstitutifs { get; set; }

        public virtual IEnumerable<DataStatComparaisonDto> LstDataStatComparaisons { get; set; }
        //public virtual IEnumerable<DataFormationDifferenceDto> DataFormationDifferences { get; set; }

        public string? LibelleViewData { get; set; }

        public int? TotalEnCommuns { get; set; }
        public int TotalUnivs { get; set; }
        public int TotalFacs { get; set; }
        public int TotalDepts { get; set; }
        public int TotalForms { get; set; }
        public int TotalUEs { get; set; }
        public int TotalECs { get; set; }
        public int TotalParcours { get; set; }
        public int TotalDomaines { get; set; }
        public int TotalMentions { get; set; }
        public int TotalSpecialites { get; set; }
        public int TotalAPs { get; set; }
        public int TotalAtomeParcours { get; set; }
        public int TotalUeParcours { get; set; }

        // Build the Processing Pipeline
        public List<string> StemmedTokens{ get; set; } = new List<string>();
        public List<int> FrequencyTokens { get; set; } = new List<int>();
        public List<string> UnivForms { get; set; } = new List<string>();
        public List<int> nbreForm { get; set; } = new List<int>();
        public List<string> UnivParcours { get; set; } = new List<string>();
        public List<int> nbreParcour { get; set; } = new List<int>();
        public List<string> UnivUEs { get; set; } = new List<string>();
        public List<int> nbreUE { get; set; } = new List<int>();
        public List<string> UnivECs { get; set; } = new List<string>();
        public List<int> nbreEC { get; set; } = new List<int>();

    }
}
