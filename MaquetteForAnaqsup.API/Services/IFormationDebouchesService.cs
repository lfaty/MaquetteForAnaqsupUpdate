using MaquetteForAnaqsup.API.Base;
using MaquetteForAnaqsup.API.Models.Domain;

namespace MaquetteForAnaqsup.API.Services
{
    public interface IFormationDebouchesService : IEntityBaseRepository<FormationDebouche>
    {
        Task<FormationDebouche> GetByIdDetail(Guid id);
        Task<FormationDebouche> GetByIdFormation(Guid idFormation);
        Task<FormationDebouche> GetByIdDebouche(Guid idDebouche);

    }
}
