using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApplication.Application.Contracts.Persistence;
using TestApplication.Persistance.Repositories;

namespace TestApplication.Persistance
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TestApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("TestApplicationConnectionString")));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));

            services.AddScoped<IContactRepasitory, ContactRepasitory>();

            return services;
        }

    }
}
