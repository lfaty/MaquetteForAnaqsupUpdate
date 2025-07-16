using MaquetteForAnaqsup.API.Base;
using MaquetteForAnaqsup.API.Data;
using MaquetteForAnaqsup.API.Models.Domain;

namespace MaquetteForAnaqsup.API.Services
{
    public class SemestresService : EntityBaseRepository<Semestre>, ISemestresService
    {
        public SemestresService(ApplicationsDbContext context) : base(context)
        {

        }
    }
}
