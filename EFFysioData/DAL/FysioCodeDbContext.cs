using Core.DomainModel;
using Microsoft.EntityFrameworkCore;

namespace EFFysioData.DAL
{
    public class FysioCodeDbContext : DbContext
    {
        public FysioCodeDbContext(DbContextOptions<FysioCodeDbContext> options)
         : base(options) { }

        public DbSet<Diagnosis> Diagnoses { get; set; }

        public DbSet<Treatment> Treatments { get; set; }
    }
}
