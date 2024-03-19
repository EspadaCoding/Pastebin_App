using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration; 
using Uncos.Application.Interfaces;
namespace Uncos.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services
                             ,IConfiguration configuration)
        {
            var connectionString = configuration["DbConnection"];
            services.AddDbContext<UncosDbContext>(option =>
            {
                option.UseSqlServer(connectionString);
            });
            services.AddScoped<IUncosDbContext>(provider => 
            provider.GetService<UncosDbContext>());
            return services;
        }
    }
}
