using MaquetteForAnaqsup.API.Base;
using MaquetteForAnaqsup.API.Models.Domain;

namespace MaquetteForAnaqsup.API.Services
{
    public interface IMentionsService : IEntityBaseRepository<Mention>
    {
        Task<Mention> GetByIdDetails(Guid id);
        Task<Mention> GetByIdDomaine(Guid idDomaine);
    }
}
