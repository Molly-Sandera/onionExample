using OninonExample.Persistence.Contexts;
using OnionExample.Application.Repositories;
using OnionExample.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OninonExample.Persistence.Repositories
{
    public class CustomerReadRepository : ReadRepository<Customer>, ICustomerReadRepository
    {
        public CustomerReadRepository(OnionExampleAPIDbContext context) : base(context)
        {

        }
    }
}
