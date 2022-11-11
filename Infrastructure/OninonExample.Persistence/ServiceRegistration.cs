using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using OninonExample.Persistence.Contexts;
using OninonExample.Persistence.Repositories;
using OnionExample.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OninonExample.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services) 
        {

            
            services.AddDbContext<OnionExampleAPIDbContext>(options=>options.UseSqlServer(Configuration.ConnectionString));
            services.AddScoped<ICustomerReadRepository,CustomerReadRepository>();
            services.AddScoped<ICustomerWriteRepository,CustomerWriteRepository>();
            services.AddScoped<IOrderReadRepository, OrderReadRepository>();
            services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();
            services.AddScoped<IProductReadRepository, ProductReadRepository>();
            services.AddScoped<IProductWriteRepository, ProductWriteRepository>();
        } 
    }
}
