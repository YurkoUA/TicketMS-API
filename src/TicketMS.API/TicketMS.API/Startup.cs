using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using TicketMS.API.Bootstrap;
using TicketMS.API.Infrastructure.Configuration;

namespace TicketMS.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IConfiguration CustomConfiguration { get; }

        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            Configuration = configuration;

            var customConfBuilder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath + "\\config\\")
                .AddJsonFile("jwtOptions.json", true, true);

            CustomConfiguration = customConfBuilder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.ConfigureAutoMapper();
            services.BindCustomConfiguration(CustomConfiguration);
            services.ConfigureDatabase(Configuration.GetConnectionString("DefaultConnection"));
            services.ConfigureRepositories();
            services.ConfigureUtilServices();
            services.ConfigureServices();
            services.ConfigureJwtAuthentication();
            services.ConfigureCors();

            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddJsonOptions(opt =>
                {
                    opt.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                    (opt.SerializerSettings.ContractResolver as DefaultContractResolver).NamingStrategy = null;

#if DEBUG
                    opt.SerializerSettings.Formatting = Formatting.Indented;
#endif
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseMvcWithDefaultRoute();
            app.UseStaticFiles();

            app.UseCors("AllowAllOrigin");
            app.UseMvc();
        }
    }
}
