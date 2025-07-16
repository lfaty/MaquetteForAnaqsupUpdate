using Microsoft.EntityFrameworkCore;
using MaquetteForAnaqsup.API.Models.Domain;
using MaquetteForAnaqsup.API.Base;
using MaquetteForAnaqsup.API.Data;


namespace MaquetteForAnaqsup.API.Services
{
    public class DomainesService : EntityBaseRepository<Domaine>, IDomainesService
    {
        public DomainesService(ApplicationsDbContext context) : base(context)
        {
           
        }
    }
}
