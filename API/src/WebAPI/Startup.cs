using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using Infrastructure.Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Data.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;
using System;
using WebAPI.Mappings;
using WebAPI.Services;
using WebAPI.ViewModels;

namespace WebAPI
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddJsonFile("config.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"config.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
            Mapper.Initialize(cfg => {
                cfg.AddProfile<DefaultProfile>();
            });
            Mapper.Configuration.AssertConfigurationIsValid();
        }

        public IContainer ApplicationContainer { get; private set; }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            var sqlConnectionString = Configuration["ConnectionStrings:DefaultConnection"];
            services.AddDbContext<TestDbContext>(options =>
                options.UseNpgsql(
                    sqlConnectionString,
                    b => b.MigrationsAssembly("WebAPI")
                )
            );

            // Add framework services.
            services.AddMvc()
                .AddJsonOptions(
                    a => a.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver());
            services.AddCors(options => options.AddPolicy("AllowAll", p => p.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin().AllowCredentials()));

            var builder = new ContainerBuilder();
            RegisterCustom(builder);
            builder.Populate(services);
            ApplicationContainer = builder.Build();

            return new AutofacServiceProvider(ApplicationContainer);
        }

        private void RegisterCustom(ContainerBuilder builder) {
            builder.RegisterModule<Application.IoC.Module>();
            builder.RegisterModule<Infrastructure.Core.IoC.Module>();

            builder.RegisterType<PageService>().As<IPageService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory,
            IApplicationLifetime appLifetime)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseCors("AllowAll");
            app.UseMvc();

            appLifetime.ApplicationStopped.Register(() => ApplicationContainer.Dispose());
        }
    }
}
