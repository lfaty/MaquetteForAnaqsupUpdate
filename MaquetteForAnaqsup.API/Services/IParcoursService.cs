using MaquetteForAnaqsup.API.Base;
using MaquetteForAnaqsup.API.Models.Domain;

namespace MaquetteForAnaqsup.API.Services
{
    public interface IParcoursService : IEntityBaseRepository<Parcour>
    {
        Task<Parcour> GetByIdDetails(Guid id);
        Task<Parcour> GetByIdFormation(Guid idFormation);
        Task<Parcour> GetByIdSemestre(Guid semestreId);
        Task<Parcour> GetByIdNiveau(Guid niveauId);
    }
}
