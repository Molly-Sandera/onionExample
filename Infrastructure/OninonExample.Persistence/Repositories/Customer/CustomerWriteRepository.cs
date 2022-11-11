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
    public class CustomerWriteRepository : WriteRepository<Customer>, ICustomerWriteRepository
    {
        public CustomerWriteRepository(OnionExampleAPIDbContext context) : base(context)
        {
        }
    }
}
