using Fysio_Codes.Models;
using Microsoft.EntityFrameworkCore;

namespace Fysio_Codes.DAL
{
    public class FysioCodeDbContext : DbContext
    {
        public FysioCodeDbContext(DbContextOptions<FysioCodeDbContext> options)
         : base(options) { }

        public DbSet<Diagnosis> Diagnoses { get; set; }

        public DbSet<Treatment> Treatments { get; set; }
    }
}
