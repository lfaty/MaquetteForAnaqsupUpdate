using MaquetteForAnaqsup.API.Base;
using MaquetteForAnaqsup.API.Models.Domain;

namespace MaquetteForAnaqsup.API.Services
{
    public interface ISpecialitesService : IEntityBaseRepository<Specialite>
    {
        Task<Specialite> GetByIdDetails(Guid id);
        Task<Specialite> GetByIdMention(Guid idMention);
    }
}
