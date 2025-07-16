namespace MaquetteForAnaqsup.API.Models.DTO
{
    public class DashboardDto
    {
        #region statistics global
        public virtual IEnumerable<ImportDataDto>? ImportDatas { get; set; }
        public virtual IEnumerable<UniversiteDto>? Universites { get; set; }
        public virtual IEnumerable<FaculteDto>? Facultes { get; set; }
        public virtual IEnumerable<DepartementDto>? Departements { get; set; }
        public virtual IEnumerable<FormationDto>? Formations { get; set; }
        public virtual IEnumerable<DomaineDto>? Domaines { get; set; }
        public virtual IEnumerable<MentionDto>? Mentions { get; set; }
        public virtual IEnumerable<SpecialiteDto>? Specialites { get; set; }
        public virtual IEnumerable<AtomePedagogiqueDto>? AtomePedagogiques { get; set; }
        public virtual IEnumerable<UniteEnseignementDto>? UniteEnseignements { get; set; }
        public virtual IEnumerable<ElementConstitutifDto>? ElementConstitutifs { get; set; }
        public virtual IEnumerable<ParcourDto>? Parcours { get; set; }
        public virtual IEnumerable<GradeDto>? Grades { get; set; }
        public virtual IEnumerable<NiveauDto>? Niveaus { get; set; }
        public virtual IEnumerable<SemestreDto>? Semestres { get; set; }
        public virtual IEnumerable<AtomeElementConstitutifDto>? AtomeElementConstitutifs { get; set; }
        public virtual IEnumerable<ParcourUniteEnseignementDto>? ParcourUniteEnseignements { get; set; }


        public virtual IEnumerable<FormationDto>? lstFormationUnivA { get; set; }
        public virtual IEnumerable<FormationDto>? lstFormationUnivB { get; set; }

        public List<FaculteDto> ListFacultes { get; set; } = new List<FaculteDto>();
        public List<DepartementDto> ListDepartements { get; set; } = new List<DepartementDto>();

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
        #endregion

        #region statistics apres recherche par mot clé
        public List<string> UnivForms { get; set; } = new List<string>();
        public List<string> UnivUEs { get; set; } = new List<string>();
        public List<string> UnivECs { get; set; } = new List<string>();
        public List<int> nbreForm { get; set; } = new List<int>();
        public List<int> nbreUE { get; set; } = new List<int>();
        public List<int> nbreEC { get; set; } = new List<int>();
        #endregion
    }
}
