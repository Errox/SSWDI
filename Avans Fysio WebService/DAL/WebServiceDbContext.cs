using MainLibrary.DomainModel;
using Microsoft.EntityFrameworkCore;


namespace Avans_Fysio_WebService.Models
{
    public class WebServiceDbContext : DbContext
    {
        public WebServiceDbContext(DbContextOptions<WebServiceDbContext> options)
            : base(options) { }

        public DbSet<Diagnosis> Diagnoses { get; set; } = default!;

        public DbSet<Treatment> Treatments { get; set; } = default!;
    }
}
