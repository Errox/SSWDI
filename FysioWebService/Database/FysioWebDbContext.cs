using MainLibrary.DomainModel;
using Microsoft.EntityFrameworkCore;

namespace FysioWebService.Database
{
    public class FysioWebDbContext : DbContext
    {
        public FysioWebDbContext(DbContextOptions<FysioWebDbContext> options)
    : base(options)
        {
        }

        public DbSet<Diagnosis> Diagnoses { get; set; }

        public DbSet<Treatment> Treatments { get; set; }
        
    }

}
