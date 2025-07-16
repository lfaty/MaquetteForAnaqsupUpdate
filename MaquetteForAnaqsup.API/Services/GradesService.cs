using MaquetteForAnaqsup.API.Base;
using MaquetteForAnaqsup.API.Data;
using MaquetteForAnaqsup.API.Models.Domain;

namespace MaquetteForAnaqsup.API.Services
{
    public class GradesService : EntityBaseRepository<Grade>, IGradesService
    {
        public GradesService(ApplicationsDbContext context) : base(context)
        {

        }
    }
}
