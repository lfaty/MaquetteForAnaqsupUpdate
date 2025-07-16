using MaquetteForAnaqsup.API.Base;
using MaquetteForAnaqsup.API.Models.Domain;

namespace MaquetteForAnaqsup.API.Services
{
    public interface IParcourUniteEnseignementsService : IEntityBaseRepository<ParcourUniteEnseignement>
    {
        Task<IEnumerable<ParcourUniteEnseignement>> GetParcourUEs(string? paramCodeUniv);
        Task<ParcourUniteEnseignement> GetByIdDetail(Guid id);
        Task<ParcourUniteEnseignement> GetByIdParcour(Guid idParcour);
        Task<ParcourUniteEnseignement> GetByIdUE(Guid idUE);
    }
}
