using MaquetteForAnaqsup.API.Base;
using MaquetteForAnaqsup.API.Models.Domain;

namespace MaquetteForAnaqsup.API.Services
{
    public interface IAnneeMaquettesService : IEntityBaseRepository<AnneeMaquette>
    {
        Task<AnneeMaquette?> StatutAsync(Guid id, AnneeMaquette entity);
    }
}
