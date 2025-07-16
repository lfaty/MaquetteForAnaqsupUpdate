using MaquetteForAnaqsup.API.Base;
using MaquetteForAnaqsup.API.Models.Domain;

namespace MaquetteForAnaqsup.API.Services
{
    public interface IDepartementsService : IEntityBaseRepository<Departement>
    {
        Task<Departement> GetByIdDetail(Guid id);
        Task<Departement> GetByIdFaculte(Guid idFaculte);
    }
}
