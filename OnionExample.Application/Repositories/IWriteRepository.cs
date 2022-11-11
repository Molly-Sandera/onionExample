using OnionExample.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionExample.Application.Repositories
{
    public interface IWriteRepository<TEntity>:IRepository<TEntity> where TEntity : BaseEntity
    {
        Task<bool> AddAsync(TEntity model);
        Task<bool> AddRangeAsync(List<TEntity> model);
        Task<bool> RemoveAsync(string Id);
        bool Remove(TEntity model);
        bool RemoveRange(List<TEntity> datas);
        bool Update(TEntity model);
        Task<int> SaveAsync();
    }
}
