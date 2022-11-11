using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using OninonExample.Persistence.Contexts;
using OnionExample.Application.Repositories;
using OnionExample.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OninonExample.Persistence.Repositories
{
    public class WriteRepository<TEntity> : IWriteRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly OnionExampleAPIDbContext _context;

        public WriteRepository(OnionExampleAPIDbContext context)
        {
            _context = context;
        }
        public DbSet<TEntity> Table => _context.Set<TEntity>();

        public async Task<bool> AddAsync(TEntity model)
        {
         EntityEntry<TEntity> entityEntry =  await Table.AddAsync(model);
            return entityEntry.State == EntityState.Added;
        }

        public async Task<bool> AddRangeAsync(List<TEntity> model)
        {
            await Table.AddRangeAsync(model);
            return true;
        }

        public async Task<bool> RemoveAsync(string Id)
        {
            TEntity model =await Table.FirstOrDefaultAsync(d=>d.Id==Guid.Parse(Id));
           return Remove(model);
        }

        public bool Remove(TEntity model)
        {
           EntityEntry entityEntry =  Table.Remove(model);
           return entityEntry.State == EntityState.Deleted;

        }

        public bool RemoveRange(List<TEntity> datas)
        {
          Table.RemoveRange(datas);
            return true;
        }

        public bool Update(TEntity model)
        {        
           EntityEntry entityEntry = Table.Update(model);
           return entityEntry.State == EntityState.Modified;
        }

        public async Task<int> SaveAsync() =>await _context.SaveChangesAsync();
       
    }
}
