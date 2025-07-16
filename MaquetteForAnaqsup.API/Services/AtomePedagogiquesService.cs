using MaquetteForAnaqsup.API.Base;
using MaquetteForAnaqsup.API.Data;
using MaquetteForAnaqsup.API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace MaquetteForAnaqsup.API.Services
{
    public class AtomePedagogiquesService : EntityBaseRepository<AtomePedagogique>, IAtomePedagogiquesService
    {
        private readonly ApplicationsDbContext _context;
        public AtomePedagogiquesService(ApplicationsDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
