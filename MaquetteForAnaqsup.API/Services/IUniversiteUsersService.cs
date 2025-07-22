using MaquetteForAnaqsup.API.Base;
using MaquetteForAnaqsup.API.Models.Domain;
using MaquetteForAnaqsup.API.Models.DTO;

namespace MaquetteForAnaqsup.API.Services
{
    public interface IUniversiteUsersService : IEntityBaseRepository<UniversiteUser>
    {
        Task<UniversiteUser> GetByIdDetail(Guid id);
        Task<UniversiteUser> GetByIdStructure(string idStructure);
        Task<UniversiteUser> GetByIdUser(string idUser);
        Task<UniversiteUser> GetByIdRole(string idRole);
        Task StatutAsync(Guid id, UniversiteUser entity);
    }
}
