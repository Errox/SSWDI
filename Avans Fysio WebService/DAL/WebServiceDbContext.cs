using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Avans_Fysio_WebService.Models
{
    public class WebServiceDbContext : DbContext
    {
        public WebServiceDbContext(DbContextOptions<WebServiceDbContext> options)
            : base(options) { }

        public DbSet<Diagnosis> Diagnoses { get; set; }

        public DbSet<Treatment> Treatments { get; set; }
    }
}
