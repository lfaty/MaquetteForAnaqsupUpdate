using Microsoft.EntityFrameworkCore;
using MaquetteForAnaqsup.API.Models.Domain;
using MaquetteForAnaqsup.API.Base;
using MaquetteForAnaqsup.API.Data;

namespace MaquetteForAnaqsup.API.Services
{
    public class FormationsService : EntityBaseRepository<Formation>, IFormationsService
    {
        private readonly ApplicationsDbContext _context;
        public FormationsService(ApplicationsDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<Formation> GetByIdDetail(Guid id)
        {
            var dataDetail = await _context.Formations
                .Include(f => f.Mention).ThenInclude(p => p.Domaine)
                .Include(f => f.Specialite).ThenInclude(p => p.Mention).ThenInclude(p => p.Domaine)
                .FirstOrDefaultAsync(f => f.Id == id);

            return dataDetail;
        }

        public async Task<Formation> GetByIdMention(Guid idMention)
        {
            var dataDetail = await _context.Formations
                .Include(f => f.Mention).ThenInclude(p => p.Domaine)
                .Include(f => f.Specialite).ThenInclude(p => p.Mention).ThenInclude(p => p.Domaine)
                .FirstOrDefaultAsync(f => f.MentionId == idMention);

            return dataDetail;
        }

        public async Task<Formation> GetByIdSpecialite(Guid idSpecialite)
        {
            var dataDetail = await _context.Formations
                .Include(f => f.Mention).ThenInclude(p => p.Domaine)
                .Include(f => f.Specialite).ThenInclude(p => p.Mention).ThenInclude(p => p.Domaine)
                .FirstOrDefaultAsync(f => f.SpecialiteId == idSpecialite);

            return dataDetail;
        }

        public async Task<Formation> GetByGrade(Grade grade)
        {
            var dataDetail = await _context.Formations
                .Include(f => f.Mention).ThenInclude(p => p.Domaine)
                .Include(f => f.Specialite).ThenInclude(p => p.Mention).ThenInclude(p => p.Domaine)
                .FirstOrDefaultAsync(f => f.Grade == grade);

            return dataDetail;
        }
    }
}
