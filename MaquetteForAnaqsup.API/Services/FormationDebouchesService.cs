using MaquetteForAnaqsup.API.Base;
using MaquetteForAnaqsup.API.Data;
using MaquetteForAnaqsup.API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace MaquetteForAnaqsup.API.Services
{
    public class FormationDebouchesService : EntityBaseRepository<FormationDebouche>, IFormationDebouchesService
    {
        private readonly ApplicationsDbContext _context;
        public FormationDebouchesService(ApplicationsDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<FormationDebouche> GetByIdDetail(Guid id)
        {
            return await _context.FormationDebouches
                .Include(f => f.Formation)
                .Include(f => f.Debouche)
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<FormationDebouche> GetByIdFormation(Guid idFormation)
        {
            return await _context.FormationDebouches
                .Include(f => f.Formation)
                .Include(f => f.Debouche)
                .FirstOrDefaultAsync(m => m.FormationId == idFormation);
        }

        public async Task<FormationDebouche> GetByIdDebouche(Guid idDebouche)
        {
            return await _context.FormationDebouches
                .Include(f => f.Formation)
                .Include(f => f.Debouche)
                .FirstOrDefaultAsync(m => m.DeboucheId == idDebouche);
        }
    }
}
