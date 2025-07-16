using MaquetteForAnaqsup.API.Base;
using MaquetteForAnaqsup.API.Data;
using MaquetteForAnaqsup.API.Models.Domain;

namespace MaquetteForAnaqsup.API.Services
{
    public class UniteEnseignementsService : EntityBaseRepository<UniteEnseignement>, IUniteEnseignementsService
    {
        public UniteEnseignementsService(ApplicationsDbContext context) : base(context)
        {
        }
    }
}
