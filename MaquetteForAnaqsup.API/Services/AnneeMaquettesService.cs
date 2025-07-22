using MaquetteForAnaqsup.API.Base;
using MaquetteForAnaqsup.API.Data;
using MaquetteForAnaqsup.API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace MaquetteForAnaqsup.API.Services
{
    public class AnneeMaquettesService : EntityBaseRepository<AnneeMaquette>, IAnneeMaquettesService
    {
        private readonly ApplicationsDbContext _context;
        public AnneeMaquettesService(ApplicationsDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<AnneeMaquette?> StatutAsync(Guid id, AnneeMaquette entity)
        {
            var data = await _context.AnneeMaquettes.FirstOrDefaultAsync(n => n.Id == id);
            if (data != null)
            {
                data.Statut = entity.Statut;
                data.DateStatut = entity.DateStatut;

                await _context.SaveChangesAsync();
            }
            return data;
        }
    }
}
