using Microsoft.EntityFrameworkCore;
using MaquetteForAnaqsup.API.Base;
using MaquetteForAnaqsup.API.Models.Domain;
using MaquetteForAnaqsup.API.Data;


namespace MaquetteForAnaqsup.API.Services
{
    public class DepartementsService : EntityBaseRepository<Departement>, IDepartementsService
    {
        private readonly ApplicationsDbContext _context;
        public DepartementsService(ApplicationsDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Departement> GetByIdDetail(Guid id)
        {
            return await _context.Departements
                .Include(f => f.Faculte)
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<Departement> GetByIdFaculte(Guid idFaculte)
        {
            return await _context.Departements
                .Include(f => f.Faculte)
                .FirstOrDefaultAsync(m => m.FaculteId == idFaculte);
        }
    }
}
