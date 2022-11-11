using Microsoft.EntityFrameworkCore;
using OninonExample.Persistence.Contexts;
using OnionExample.Application.Repositories;
using OnionExample.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OninonExample.Persistence.Repositories
{
    public class ReadRepository<TEntity> : IReadRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly OnionExampleAPIDbContext _context;

        public ReadRepository(OnionExampleAPIDbContext context)
        {
            _context = context;
        }

        public DbSet<TEntity> Table => _context.Set<TEntity>();


        public IQueryable<TEntity> GetAll(bool tracking = true) {

            var query = Table.AsQueryable();
            if (!tracking)
              query =   query.AsNoTracking();
            return query;
        }

        public async Task<TEntity> GetByIdAsync(string Id, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = Table.AsNoTracking();


            return await query.FirstOrDefaultAsync(a => a.Id == Guid.Parse(Id));

        }



        public async Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> method, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = Table.AsNoTracking();
            return await query.FirstOrDefaultAsync(method);
            



        } 

        public IQueryable<TEntity> GetWhere(Expression<Func<TEntity, bool>> method, bool tracking = true) { 
        
        var query = Table.Where(method).AsQueryable();
            if (tracking!)
                query = query.AsNoTracking();
            return query;
            

            


        } 
        
    }
}
