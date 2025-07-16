using MaquetteForAnaqsup.API.Base;
using MaquetteForAnaqsup.API.Models.Domain;

namespace MaquetteForAnaqsup.API.Services
{
    public interface IElementConstitutifsService : IEntityBaseRepository<ElementConstitutif>
    {
        Task<ElementConstitutif> GetByIdDetail(Guid id);
        Task<ElementConstitutif> GetByIdUE(Guid idUE);
    }
}
