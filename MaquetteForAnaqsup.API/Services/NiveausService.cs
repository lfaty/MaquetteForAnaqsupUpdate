﻿using MaquetteForAnaqsup.API.Base;
using MaquetteForAnaqsup.API.Data;
using MaquetteForAnaqsup.API.Models.Domain;

namespace MaquetteForAnaqsup.API.Services
{
    public class NiveausService : EntityBaseRepository<Niveau>, INiveausService
    {
        public NiveausService(ApplicationsDbContext context) : base(context)
        {

        }
    }
}
