using MaquetteForAnaqsup.API.Base;
using MaquetteForAnaqsup.API.Models.Domain;
using MaquetteForAnaqsup.API.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace MaquetteForAnaqsup.API.Services
{
    public interface IDatasService
    {
        Task<IEnumerable<ImportData>> GetAllAsync();
        Task<IEnumerable<ImportData>> GetFilterDataAsync(string? paramCodeUniv, string? paramDept, string? paramGrade, string? paramFormation, int? paramNiveau, int? paramSemestre, string? paramParcour);
        Task<IEnumerable<ImportData>> GetFormationCommuneAsync(DataParameterDto dataParameter);
        Task<IEnumerable<ImportData>> GetFormationDifferenceAsync(DataParameterDto dataParameter);
        Task<IEnumerable<ImportData>> GetStatECSearch(string? paramLibelleEC);
        Task<IEnumerable<DataStatComparaisonDto>> GetStatComparaisonAsync();
        Task<IEnumerable<DataUniversiteDto>> GetStatUniversiteAsync();
        Task<IEnumerable<DataDepartementDto>> GetStatDepartementAsync();
        Task<IEnumerable<DataGradeDto>> GetStatGradeAsync();
        Task<IEnumerable<DataNiveauDto>> GetStatNiveauAsync();
        Task<IEnumerable<DataSemestreDto>> GetStatSemestreAsync();
        Task<IEnumerable<DataFormationDto>> GetStatFormationAsync();
        Task<IEnumerable<DataParcourDto>> GetStatParcourAsync();
        Task<IEnumerable<DataUniteEnseignementDto>> GetStatUniteEnseignementAsync();
        Task<IEnumerable<DataElementConstitutifDto>> GetStatElementConstitutifAsync();
    }
}
