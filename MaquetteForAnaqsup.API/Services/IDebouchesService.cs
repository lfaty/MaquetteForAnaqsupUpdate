using MaquetteForAnaqsup.API.Base;
using MaquetteForAnaqsup.API.Models.Domain;

namespace MaquetteForAnaqsup.API.Services
{
    public interface IDebouchesService : IEntityBaseRepository<Debouche>
    {
        Task<Debouche> GetByIdDetail(Guid id);
        Task<Debouche> GetByIdFormation(Guid idFormation);

    }
}
