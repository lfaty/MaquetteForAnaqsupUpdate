using Microsoft.EntityFrameworkCore;
using MaquetteForAnaqsup.API.Models.Domain;
using MaquetteForAnaqsup.API.Base;
using MaquetteForAnaqsup.API.Data;

namespace MaquetteForAnaqsup.API.Services
{
    public class UniversitesService : EntityBaseRepository<Universite>, IUniversitesService
    {
        private readonly ApplicationsDbContext _context;
        public UniversitesService(ApplicationsDbContext context) : base(context)
        {
            _context = context;
        }

        //public async Task<Universite> GetByIdDetails(Guid id)
        //{
        //    return await _context.Universites
        //        .Include(f => f.Ville)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //}
    }
}
