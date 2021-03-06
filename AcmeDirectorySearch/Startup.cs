﻿using AcmeDirectorySearch.Core;
using AcmeDirectorySearch.Core.Interfaces;
using AcmeDirectorySearch.Core.Services;
using AcmeDirectorySearch.Infrastructure;
using AcmeDirectorySearch.Infrastructure.Interfaces;
using AcmeDirectorySearch.Infrastructure.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AcmeDirectorySearch
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private readonly string AllowCorsAllPolicy = "_allowCorsAll";
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

            // Add ability to communicate from front-end on different port
            services.AddCors(options =>
            {
                options.AddPolicy(this.AllowCorsAllPolicy,
                builder =>
                {
                    builder.WithOrigins(this.Configuration.GetSection("Cors")["api"])
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseExceptionHandler(new ExceptionHandlerOptions
            {
                ExceptionHandler = new JsonGlobalExceptionHandler(env).Invoke,
            });

            app.UseCors(this.AllowCorsAllPolicy);
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
