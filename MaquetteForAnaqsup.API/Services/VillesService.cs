using MaquetteForAnaqsup.API.Base;
using MaquetteForAnaqsup.API.Data;
using MaquetteForAnaqsup.API.Models.Domain;

namespace MaquetteForAnaqsup.API.Services
{
    public class VillesService : EntityBaseRepository<Ville>, IVillesService
    {
        public VillesService(ApplicationsDbContext context) : base(context)
        {

        }
    }
}
