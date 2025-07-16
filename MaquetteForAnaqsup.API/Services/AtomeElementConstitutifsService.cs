using MaquetteForAnaqsup.API.Base;
using MaquetteForAnaqsup.API.Data;
using MaquetteForAnaqsup.API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace MaquetteForAnaqsup.API.Services
{
    public class AtomeElementConstitutifsService : EntityBaseRepository<AtomeElementConstitutif>, IAtomeElementConstitutifsService
    {
        private readonly ApplicationsDbContext _context;
        public AtomeElementConstitutifsService(ApplicationsDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<AtomeElementConstitutif> GetByIdDetail(Guid id)
        {
            var detail = await _context.AtomeElementConstitutifs
                .Include(f => f.ElementConstitutif).ThenInclude(a => a.UniteEnseignement)
                .Include(n =>n.AtomePedagogique)
                .FirstOrDefaultAsync(m => m.Id == id);
            return detail;
        }

        public async Task<AtomeElementConstitutif> GetByIdEC(Guid idEC)
        {
            var detail = await _context.AtomeElementConstitutifs
                .Include(f => f.ElementConstitutif).ThenInclude(a => a.UniteEnseignement)
                .Include(n => n.AtomePedagogique)
                .FirstOrDefaultAsync(m => m.ElementConstitutifId == idEC);
            return detail;
        }

        public async Task<AtomeElementConstitutif> GetByIdAP(Guid idAP)
        {
            var detail = await _context.AtomeElementConstitutifs
                .Include(f => f.ElementConstitutif).ThenInclude(a => a.UniteEnseignement)
                .Include(n => n.AtomePedagogique)
                .FirstOrDefaultAsync(m => m.AtomePedagogiqueId == idAP);
            return detail;
        }

        public async Task<IEnumerable<AtomeElementConstitutif>> GetAllDataAsync()
        {
            var filteredData = await _context.AtomeElementConstitutifs
                .Include(x => x.AtomePedagogique)
                .Include(x => x.ElementConstitutif)
                .ThenInclude(u=>u.UniteEnseignement)
                .ThenInclude(x=>x.ParcourUniteEnseignements).ThenInclude(p=>p.Parcour).ThenInclude(f=>f.Formation)
                .Take(50).ToListAsync();
            return filteredData;
        }

        //public async Task<IEnumerable<AtomeElementConstitutif>> GetFilterDataAsync(string? paramCodeUniv, string? paramFaculte, string? paramDept, string? paramGrade, string? paramFormation, int? paramNiveau, int? paramSemestre, string? paramParcour)
        //{
        //    var filteredData = await _context.UeParcours.Where(x => x.VolumeHoraire >= 10).OrderBy(x => x.LibelleFormation).Take(500).ToListAsync();

        //    // Filtering paramCodeUniv
        //    if (string.IsNullOrWhiteSpace(paramCodeUniv) == false)
        //    {
        //        filteredData = filteredData.Where(x => x.CodeUniversite == paramCodeUniv).ToList();
        //    }

        //    // Filtering paramFaculte
        //    if (string.IsNullOrWhiteSpace(paramFaculte) == false)
        //    {
        //        filteredData = filteredData.Where(x => x.Faculte == paramFaculte).ToList();
        //    }

        //    // Filtering paramDept
        //    if (string.IsNullOrWhiteSpace(paramDept) == false)
        //    {
        //        filteredData = filteredData.Where(x => x.Departement == paramDept).ToList();
        //    }

        //    // Filtering paramGrade
        //    if (string.IsNullOrWhiteSpace(paramGrade) == false)
        //    {
        //        filteredData = filteredData.Where(x => x.Grade == paramGrade).ToList();
        //    }

        //    // Filtering paramFormation
        //    if (string.IsNullOrWhiteSpace(paramFormation) == false)
        //    {
        //        filteredData = filteredData.Where(x => x.LibelleFormation == paramFormation).ToList();
        //    }

        //    // Filtering paramNiveau
        //    if (paramNiveau > 0)
        //    {
        //        filteredData = filteredData.Where(x => x.Niveau == paramNiveau).ToList();
        //    }

        //    // Filtering paramSemestre
        //    if (paramSemestre > 0)
        //    {
        //        filteredData = filteredData.Where(x => x.Semestre == paramSemestre).ToList();
        //    }

        //    // Filtering paramParcour
        //    if (string.IsNullOrWhiteSpace(paramParcour) == false)
        //    {
        //        filteredData = filteredData.Where(x => x.Parcours == paramParcour).ToList();
        //    }

        //    return filteredData;
        //}
    }
}
