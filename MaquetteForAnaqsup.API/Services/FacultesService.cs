
using MaquetteForAnaqsup.API.Base;
using MaquetteForAnaqsup.API.Data;
using MaquetteForAnaqsup.API.Models.Domain;
using MaquetteForAnaqsup.API.Services;

namespace MaquetteForAnaqsup.API.Services
{
    public class FacultesService : EntityBaseRepository<Faculte>, IFacultesService
    {
        public FacultesService(ApplicationsDbContext context) : base(context)
        {
            
        }
    }
}
