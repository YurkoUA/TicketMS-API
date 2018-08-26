using System;
using System.Security.Cryptography;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using TicketMS.API.Data;
using TicketMS.API.Infrastructure.Database;
using TicketMS.API.Infrastructure.Interfaces;
using TicketMS.API.Infrastructure.Util;
using TicketMS.API.Infrastructure.Repositories;
using TicketMS.API.Data.Repositories;

namespace TicketMS.API.Bootstrap
{
    public static class ServiceCollectionExtensions
    {
        public static void ConfigureAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper();
        }

        public static void ConfigureDatabase(this IServiceCollection services, string connectionString)
        {
            services.AddScoped<IDbContext>(provider => new DbContext(connectionString));
        }

        public static void ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ILoginRepository, LoginRepository>();

            services.AddScoped<INominalRepository, NominalRepository>();
            services.AddScoped<IColorRepository, ColorRepository>();
            services.AddScoped<ISerialRepository, SerialRepository>();
            services.AddScoped<IPackageRepository, PackageRepository>();
            services.AddScoped<ITicketRepository, TicketRepository>();

            services.AddScoped<ITicketSummaryRepository, TicketSummaryRepository>();
            services.AddScoped<ITicketNotesRepository, TicketNotesRepository>();

            services.AddScoped<IReportRepository, ReportRepository>();
            services.AddScoped<IReportDataRepository, ReportDataRepository>();

            services.AddScoped<ISummaryRepository, SummaryRepository>();
            services.AddScoped<IStatisticsRepository, StatisticsRepository>();
        }

        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddSingleton<IMappingService, MappingService>();

            services.AddSingleton<ICryptoService>(provider =>
            {
                return new CryptoService(new RNGCryptoServiceProvider(), new SHA512CryptoServiceProvider());
            });
        }
    }
}
