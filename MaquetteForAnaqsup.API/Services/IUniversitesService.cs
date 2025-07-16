using MaquetteForAnaqsup.API.Base;
using MaquetteForAnaqsup.API.Models.Domain;

namespace MaquetteForAnaqsup.API.Services
{
    public interface IUniversitesService : IEntityBaseRepository<Universite>
    {
        //Task<Universite> GetByIdDetails(Guid id);
    }
}
