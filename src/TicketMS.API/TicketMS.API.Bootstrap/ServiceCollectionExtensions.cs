using System;
using Microsoft.Extensions.DependencyInjection;
using TicketMS.API.Data;
using TicketMS.API.Infrastructure.Database;

namespace TicketMS.API.Bootstrap
{
    public static class ServiceCollectionExtensions
    {
        public static void ConfigureAutoMapper(this IServiceCollection services)
        {

        }

        public static void ConfigureDatabase(this IServiceCollection services, string connectionString)
        {
            services.AddScoped<IDbContext, DbContext>(provider => new DbContext(connectionString));
        }

        public static void ConfigureRepositories(this IServiceCollection services)
        {

        }

        public static void ConfigureServices(this IServiceCollection services)
        {

        }
    }
}
