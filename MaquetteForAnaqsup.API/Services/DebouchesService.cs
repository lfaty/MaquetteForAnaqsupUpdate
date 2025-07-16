using MaquetteForAnaqsup.API.Base;
using MaquetteForAnaqsup.API.Data;
using MaquetteForAnaqsup.API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace MaquetteForAnaqsup.API.Services
{
    public class DebouchesService : EntityBaseRepository<Debouche>, IDebouchesService
    {
        private readonly ApplicationsDbContext _context;
        public DebouchesService(ApplicationsDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Debouche> GetByIdDetail(Guid id)
        {
            return await _context.Debouches
                .Include(f => f.Formation)
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<Debouche> GetByIdFormation(Guid idFormation)
        {
            return await _context.Debouches
                .Include(f => f.Formation)
                .FirstOrDefaultAsync(m => m.FormationId == idFormation);
        }
    }
}
