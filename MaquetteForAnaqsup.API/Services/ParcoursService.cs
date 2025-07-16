using MaquetteForAnaqsup.API.Base;
using MaquetteForAnaqsup.API.Data;
using MaquetteForAnaqsup.API.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace MaquetteForAnaqsup.API.Services
{
    public class ParcoursService : EntityBaseRepository<Parcour>, IParcoursService
    {
        private readonly ApplicationsDbContext _context;
        public ParcoursService(ApplicationsDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Parcour> GetByIdDetails(Guid id)
        {
            var data = await _context.Parcours
                .Include(f => f.Formation)
                .FirstOrDefaultAsync(m => m.Id == id);
            return data;
        }

        public async Task<Parcour> GetByIdFormation(Guid idFormation)
        {
            var data = await _context.Parcours
                .Include(f => f.Formation)
                .FirstOrDefaultAsync(m => m.FormationId == idFormation);
            return data;
        }

        public async Task<Parcour> GetByIdNiveau(Guid niveauId)
        {
            var data = await _context.Parcours
            .Include(f => f.Formation)
                .FirstOrDefaultAsync(m => m.NiveauId == niveauId);
            return data;
        }

        public async Task<Parcour> GetByIdSemestre(Guid semestreId)
        {
            var data = await _context.Parcours
            .Include(f => f.Formation)
                .FirstOrDefaultAsync(m => m.SemestreId == semestreId);
            return data;
        }
    }
}
