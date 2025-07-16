using MaquetteForAnaqsup.API.Base;
using MaquetteForAnaqsup.API.Models.Domain;

namespace MaquetteForAnaqsup.API.Services
{
    public interface IAtomeElementConstitutifsService : IEntityBaseRepository<AtomeElementConstitutif>
    {
        Task<AtomeElementConstitutif> GetByIdDetail(Guid id);
        Task<AtomeElementConstitutif> GetByIdEC(Guid idEC);
        Task<AtomeElementConstitutif> GetByIdAP(Guid idAP);

        Task<IEnumerable<AtomeElementConstitutif>> GetAllDataAsync();
        //Task<IEnumerable<AtomeElementConstitutif>> GetFilterDataAsync(string? paramCodeUniv, string? paramFaculte, string? paramDept, string? paramGrade, string? paramFormation, int? paramNiveau, int? paramSemestre, string? paramParcour);
    }
}
