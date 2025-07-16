using MaquetteForAnaqsup.API.Base;
using MaquetteForAnaqsup.API.Data;
using MaquetteForAnaqsup.API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace MaquetteForAnaqsup.API.Services
{
    public class SpecialitesService : EntityBaseRepository<Specialite>, ISpecialitesService
    {
        private readonly ApplicationsDbContext _context;
        public SpecialitesService(ApplicationsDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Specialite> GetByIdDetails(Guid id)
        {
            return await _context.Specialites
                .Include(f => f.Mention)
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<Specialite> GetByIdMention(Guid idMention)
        {
            return await _context.Specialites
                .Include(f => f.Mention)
                .FirstOrDefaultAsync(m => m.MentionId == idMention);
        }
    }
}
