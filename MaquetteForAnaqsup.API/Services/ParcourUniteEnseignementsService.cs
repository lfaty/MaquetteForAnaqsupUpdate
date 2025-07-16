using MaquetteForAnaqsup.API.Base;
using MaquetteForAnaqsup.API.Data;
using MaquetteForAnaqsup.API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace MaquetteForAnaqsup.API.Services
{
    public class ParcourUniteEnseignementsService : EntityBaseRepository<ParcourUniteEnseignement>, IParcourUniteEnseignementsService
    {
        private readonly ApplicationsDbContext _context;
        public ParcourUniteEnseignementsService(ApplicationsDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<ParcourUniteEnseignement> GetByIdDetail(Guid id)
        {
            var detail = await _context.ParcourUniteEnseignements
                .Include(f => f.Parcour).ThenInclude(a => a.Formation)
                .Include(n =>n.UniteEnseignement)
                .FirstOrDefaultAsync(m => m.Id == id);
            return detail;
        }

        public async Task<ParcourUniteEnseignement> GetByIdParcour(Guid idParcour)
        {
            var detail = await _context.ParcourUniteEnseignements
                .Include(f => f.Parcour).ThenInclude(a => a.Formation)
                .Include(n => n.UniteEnseignement)
                .FirstOrDefaultAsync(m => m.ParcourId == idParcour);
            return detail;
        }

        public async Task<ParcourUniteEnseignement> GetByIdUE(Guid idUE)
        {
            var detail = await _context.ParcourUniteEnseignements
                .Include(f => f.Parcour).ThenInclude(a => a.Formation)
                .Include(n => n.UniteEnseignement)
                .FirstOrDefaultAsync(m => m.UniteEnseignementId == idUE);
            return detail;
        }

        public async Task<IEnumerable<ParcourUniteEnseignement>> GetParcourUEs(string? paramCodeUniv)
        {
            var datas = await _context.ParcourUniteEnseignements.Where(x=>x.CodeUniv == paramCodeUniv).Include(f => f.Parcour).ThenInclude(a => a.Formation)
                .Include(n => n.UniteEnseignement).ToListAsync();
            return datas;
        }
    }
}
