using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcmeDirectorySearch.Core;
using AcmeDirectorySearch.Core.Interfaces;
using AcmeDirectorySearch.Core.Services;
using AcmeDirectorySearch.Infrastructure;
using AcmeDirectorySearch.Infrastructure.Interfaces;
using AcmeDirectorySearch.Infrastructure.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace AcmeDirectorySearch
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Use Options Pattern for injecting database connection string
            services.Configure<DatabaseOptions>(this.Configuration.GetSection("Database"));

            // Setup dependency injection for services / repos
            services.AddAutoMapper(typeof(Startup));
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IPropertyService, PropertyService>();
            services.AddTransient<IPropertyRepository, PropertyRepository>();


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

         /*   app.UseExceptionHandler(new ExceptionHandlerOptions
            {
                ExceptionHandler = new JsonGlobalExceptionHandler(env).Invoke,
            });*/

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
