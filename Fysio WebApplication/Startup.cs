using Core.DomainModel;
using DomainServices.Repositories;
using DomainServices.Services;
using EFFysioData.DAL;
using EFFysioData.Repositories;
using EFFysioData.SeedData;
using GraphQL.Client.Abstractions;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Services;

namespace Fysio_WebApplication
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("ApplicationDevConnection")));

            services.AddDbContext<AppIdentityDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("IdentityDevConnection")));

            //services.AddDbContext<ApplicationDbContext>(options =>
            //    options.UseSqlServer(
            //        Configuration.GetConnectionString("ApplicationConnection")));

            //services.AddDbContext<AppIdentityDbContext>(options =>
            //    options.UseSqlServer(
            //        Configuration.GetConnectionString("IdentityConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<AppIdentityDbContext>()
                .AddDefaultTokenProviders();

            services.AddAuthorization(options =>
            {
                options.AddPolicy("RequireEmployeeRole",
                    policy => policy.RequireClaim("UserType", "Employee"));
                options.AddPolicy("RequireStudentRole",
                    policy => policy.RequireClaim("UserType", "Student"));
                options.AddPolicy("RequirePatientRole",
                    policy => policy.RequireClaim("UserType", "Patient"));
                options.AddPolicy("OnlyEmployeeAndStudent",
                    policy => policy.RequireClaim("UserType", "Employee", "Student"));
            });

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/auth/Login";
                options.AccessDeniedPath = "/Account/AccessDenied";
            });


            // Setup Controller and Razor pages
            services.AddControllersWithViews();
            services.AddRazorPages().AddRazorRuntimeCompilation();

            // Import graphql client
            services.AddScoped<IGraphQLClient>(s => new GraphQLHttpClient(Configuration.GetConnectionString("GraphqlUrl"), new NewtonsoftJsonSerializer()));

            // Dependency injection repository
            services.AddTransient<IAppointmentsRepository, EFAppointmentRepository>();
            services.AddTransient<IAvailabilityRepository, EFAvailabilityRepository>();
            services.AddTransient<ITreatmentPlanRepository, EFTreatmentPlanRepository>();
            services.AddTransient<IPracticeRoomRepository, EFPracticeRoomRepository>();
            services.AddTransient<IPatientRepository, EFPatientRepository>();
            services.AddTransient<INotesRepository, EFNotesRepository>();
            services.AddTransient<IMedicalFileRepository, EFMedicalFileRepository>();
            services.AddTransient<IEmployeeRepository, EFEmployeeRepository>();

            // Dependency injection Services.
            services.AddTransient<IAppointmentsService, AppointmentService>();
            services.AddTransient<IAvailabilityService, AvailabilityService>();
            services.AddTransient<ITreatmentPlanService, TreatmentPlanService>();
            services.AddTransient<IPracticeRoomService, PracticeRoomService>();
            services.AddTransient<IPatientService, PatientService>();
            services.AddTransient<INotesService, NotesService>();
            services.AddTransient<IMedicalFileService, MedicalFileService>();
            services.AddTransient<IEmployeeService, EmployeeService>();
            services.AddMemoryCache();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseStatusCodePagesWithReExecute("/Error", "?code={0}");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });


            // ensure Populated
            IdentitySeedData.EnsurePopulated(app);

        }
    }
}
