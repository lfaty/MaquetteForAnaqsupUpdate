using MaquetteForAnaqsup.API.Base;
using MaquetteForAnaqsup.API.Models.Domain;

namespace MaquetteForAnaqsup.API.Services
{
    public interface IFormationsService : IEntityBaseRepository<Formation>
    {
        Task<Formation> GetByIdDetail(Guid id);
        Task<Formation> GetByIdMention(Guid idMention);
        Task<Formation> GetByIdSpecialite(Guid idSpecialite);
        Task<Formation> GetByGrade(Grade grade);
    }
}
