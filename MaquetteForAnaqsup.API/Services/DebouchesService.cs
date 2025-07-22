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
        }
    }
}
