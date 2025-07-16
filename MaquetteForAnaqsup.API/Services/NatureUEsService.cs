using MaquetteForAnaqsup.API.Base;
using MaquetteForAnaqsup.API.Data;
using MaquetteForAnaqsup.API.Models.Domain;

namespace MaquetteForAnaqsup.API.Services
{
    public class NatureUEsService : EntityBaseRepository<NatureUniteEnseignement>, INatureUEsService
    {
        public NatureUEsService(ApplicationsDbContext context) : base(context)
        {

        }
    }
}
