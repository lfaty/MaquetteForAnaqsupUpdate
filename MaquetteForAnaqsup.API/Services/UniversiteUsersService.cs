using Microsoft.EntityFrameworkCore;
using MaquetteForAnaqsup.API.Models.Domain;
using MaquetteForAnaqsup.API.Base;
using MaquetteForAnaqsup.API.Data;

namespace MaquetteForAnaqsup.API.Services
{
    public class UniversiteUsersService : EntityBaseRepository<UniversiteUser>, IUniversiteUsersService
    {
        private readonly ApplicationsDbContext _context;
        public UniversiteUsersService(ApplicationsDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<UniversiteUser> GetByIdDetail(Guid id)
        {
            var detail = await _context.UniversiteUsers.FirstOrDefaultAsync(m => m.Id == id);
            return detail;
        }

        public async Task<UniversiteUser> GetByIdStructure(string idStructure)
        {
            var detail = await _context.UniversiteUsers.FirstOrDefaultAsync(m => m.UniversiteId == idStructure);
            return detail;
        }

        public async Task<UniversiteUser> GetByIdUser(string idUser)
        {
            var detail = await _context.UniversiteUsers.FirstOrDefaultAsync(m => m.UserId == idUser);
            return detail;
        }

        public async Task<UniversiteUser> GetByIdRole(string idRole)
        {
            var detail = await _context.UniversiteUsers.FirstOrDefaultAsync(m => m.RoleId == idRole);
            return detail;
        }

        public async Task StatutAsync(Guid id, UniversiteUser entity)
        {
            var data = await _context.UniversiteUsers.FirstOrDefaultAsync(n => n.Id == id);
            if (data != null)
            {
                data.Statut = entity.Statut;
                data.DateStatut = entity.DateStatut;

                await _context.SaveChangesAsync();
            }
        }
    }
}
