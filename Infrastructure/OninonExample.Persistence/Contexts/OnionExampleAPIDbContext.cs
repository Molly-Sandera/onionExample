using Microsoft.EntityFrameworkCore;
using OnionExample.Domain.Entities;
using OnionExample.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OninonExample.Persistence.Contexts
{
    public class OnionExampleAPIDbContext : DbContext
    {
        public OnionExampleAPIDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
          var  datas = ChangeTracker.Entries<BaseEntity>();

            foreach (var data in datas)
            {
                _= data.State switch
                {
                    EntityState.Added=>data.Entity.CreatedDate=DateTime.Now,
                    EntityState.Modified=>data.Entity.ModifiedDate = DateTime.Now

                };
            }
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
