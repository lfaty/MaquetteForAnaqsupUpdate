
using MaquetteForAnaqsup.API.Base;
using MaquetteForAnaqsup.API.Data;
using MaquetteForAnaqsup.API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace MaquetteForAnaqsup.API.Services
{
    public class ElementConstitutifsService : EntityBaseRepository<ElementConstitutif>, IElementConstitutifsService
    {
        readonly ApplicationsDbContext _context;
        public ElementConstitutifsService(ApplicationsDbContext context) : base(context)
        {
            _context = context; 
        }

        public async Task<ElementConstitutif> GetByIdDetail(Guid id)
        {
            var dataDetail = await _context.ElementConstitutifs
                .Include(o => o.UniteEnseignement)
                .FirstOrDefaultAsync(f => f.Id == id);
            return dataDetail;
        }

        public async Task<ElementConstitutif> GetByIdUE(Guid idUE)
        {
            var dataDetail = await _context.ElementConstitutifs
                .Include(o => o.UniteEnseignement)
                .FirstOrDefaultAsync(f => f.UniteEnseignementId == idUE);
            return dataDetail;
        }
    }
}
