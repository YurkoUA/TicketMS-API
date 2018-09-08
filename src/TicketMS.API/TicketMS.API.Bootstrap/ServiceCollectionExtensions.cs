using System.Security.Cryptography;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using AutoMapper;
using TicketMS.API.Data;
using TicketMS.API.Infrastructure.Database;
using TicketMS.API.Infrastructure.Interfaces;
using TicketMS.API.Infrastructure.Util;
using TicketMS.API.Infrastructure.Repositories;
using TicketMS.API.Data.Repositories;
using TicketMS.API.Infrastructure.Services;
using TicketMS.API.Business.Security;
using TicketMS.API.Business.Services;
using TicketMS.API.Infrastructure.Configuration;

namespace TicketMS.API.Bootstrap
{
    public static class ServiceCollectionExtensions
    {
        public static void BindCustomConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddOptions();
            services.Configure<JwtOptions>(configuration.GetSection(nameof(JwtOptions)));
        }

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

        public static void ConfigureUtilServices(this IServiceCollection services)
        {
            services.AddScoped<IMappingService, MappingService>();
        }

        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddSingleton<ICryptoService>(provider =>
            {
                return new CryptoService(new RNGCryptoServiceProvider(), new SHA512CryptoServiceProvider());
            });

            services.AddSingleton<IClaimService, ClaimService>();
            services.AddSingleton<IJwtService, JwtService>();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<IUserAuthenticationService, UserAuthenticationService>();
        }

        public static void ConfigureJwtAuthentication(this IServiceCollection services, JwtOptions jwtOptions)
        {
            var validationParams = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = jwtOptions.Issuer,

                ValidateAudience = true,
                ValidAudience = jwtOptions.Audience,

                ValidateIssuerSigningKey = true,
                IssuerSigningKey = jwtOptions.SignInKey,

                ValidateLifetime = true
            };

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(opts =>
                {
                    opts.RequireHttpsMetadata = false;
                    opts.TokenValidationParameters = validationParams;
                });

            services.AddAuthorization(opts =>
            {
                opts.DefaultPolicy = new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme)
                    .RequireAuthenticatedUser()
                    .Build();
            });
        }

        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(opt =>
            {
                opt.AddPolicy("AllowAllOrigin", builder =>
                {
                    builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials();
                });
            });
        }
    }
}
