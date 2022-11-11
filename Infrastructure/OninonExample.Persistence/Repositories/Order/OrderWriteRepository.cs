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
    public class OrderWriteRepository : WriteRepository<Order>, IOrderWriteRepository
    {
        public OrderWriteRepository(OnionExampleAPIDbContext context) : base(context)
        {
        }
    }
}
