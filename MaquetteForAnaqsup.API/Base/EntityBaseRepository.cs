using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Xml;
using MaquetteForAnaqsup.API.Data;

namespace MaquetteForAnaqsup.API.Base
{
    public class EntityBaseRepository<T> : IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {
        private readonly ApplicationsDbContext _context;

        public EntityBaseRepository(ApplicationsDbContext context)
        {
            _context = context;
        }

        public async Task<T> AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
            EntityEntry entityEntry = _context.Entry<T>(entity);
            entityEntry.State = EntityState.Deleted;

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync(string? filterUniv = null)
        {
            var datas = await _context.Set<T>().ToListAsync();

            // Filtering
            if (string.IsNullOrWhiteSpace(filterUniv) == false)
            {
                datas = datas.Where(x => x.CodeUniv == filterUniv).ToList();
            }

            return datas;
        }

        public async Task<IEnumerable<T>> GetAllAsync(string? filterUniv = null, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _context.Set<T>();
            query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

            var datas = await query.ToListAsync();

            // Filtering
            if (string.IsNullOrWhiteSpace(filterUniv) == false)
            {
                datas = datas.Where(x => x.CodeUniv == filterUniv).ToList();
            }

            return datas;
        }

        public async Task<T> GetByIdAsync(Guid id) => await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);


        public async Task<T> UpdateAsync(T entity)
        {
            EntityEntry entityEntry = _context.Entry<T>(entity);
            entityEntry.State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return entity;
        }

    }
}
