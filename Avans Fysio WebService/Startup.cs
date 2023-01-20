using Avans_Fysio_WebService.GraphQL;
using Avans_Fysio_WebService.GraphQL.Mutations;
using DomainServices.Repositories;
using DomainServices.Services;
using EFFysioData.DAL;
using EFFysioData.Repositories;
using EFFysioData.SeedData;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using Services;

namespace Avans_Fysio_WebService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            //services.AddDbContextFactory<FysioCodeDbContext>(opts =>
            //{
            //    opts.UseSqlServer(
            //        Configuration["ConnectionStrings:AvansFysioDevWebServiceConnection"]);
            //});
            services.AddDbContextFactory<FysioCodeDbContext>(opts =>
            {
                opts.UseSqlServer(
                    Configuration["ConnectionStrings:AvansFysioWebServiceConnection"]);
            });

            // Dependency injection Repository's
            services.AddTransient<IDiagnosesRepository, EFDiagnoseRepository>();
            services.AddTransient<ITreatmentRepository, EFTreatmentRepository>();

            // Dependency injection for Services
            services.AddTransient<IDiagnosesService, DiagnosesService>();
            services.AddTransient<ITreatmentServices, TreatmentService>();

            //GraphQL 
            services
                .AddGraphQLServer()
                .AddQueryType<Query>()
                .AddMutationType<Mutation>();

            // Register the swagger generator
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Avans Fysio Webservice",
                    Description = "A simple API made for the Diagnosis and treatments. Used by the Fysio Web Application.",
                    Contact = new OpenApiContact
                    {
                        Name = "Github repo URL ",
                        Email = string.Empty,
                        Url = new Uri("https://github.com/Errox/SSWDI"),
                    }
                });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.)
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Avans Fysio WebService V1");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapGraphQL();
            });

            SeedDataWebService.EnsurePopulated(app);
        }
    }
}
