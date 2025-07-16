using Microsoft.EntityFrameworkCore;
using MaquetteForAnaqsup.API.Models.Domain;
using MaquetteForAnaqsup.API.Base;
using MaquetteForAnaqsup.API.Data;

namespace MaquetteForAnaqsup.API.Services
{
    public class MentionsService : EntityBaseRepository<Mention>, IMentionsService
    {
        private readonly ApplicationsDbContext _context;
        public MentionsService(ApplicationsDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Mention> GetByIdDetails(Guid id)
        {
            return await _context.Mentions
                .Include(f => f.Domaine)
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<Mention> GetByIdDomaine(Guid idDomaine)
        {
            return await _context.Mentions
                .Include(f => f.Domaine)
                .FirstOrDefaultAsync(m => m.DomaineId == idDomaine);
        }
    }
}
