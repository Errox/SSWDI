using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CsvHelper;
using System.Threading.Tasks;
using EFCore.Seeder;
using EFCore.Seeder.Extensions;
using EFCore.Seeder.Configuration;
using System.IO;
using System.Globalization;

namespace Avans_Fysio_WebService.Models
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {

            WebServiceDbContext context = app.ApplicationServices
                .CreateScope().ServiceProvider.GetRequiredService<WebServiceDbContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            if (!context.Diagnoses.Any())
            {
                using (var reader = new StreamReader("SeedData\\VektisLijstDiagnoses.csv"))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    csv.Read();
                    csv.ReadHeader();

                    while (csv.Read())
                    {
                        context.Add(new Diagnosis { Code = int.Parse(csv.GetField(0)),  BodyLocation = csv.GetField(1), Pathology =  csv.GetField(2)});
                    }
                    
                }
                context.SaveChanges();
            }

            if (!context.Treatments.Any())
            {
                using (var reader = new StreamReader("SeedData\\VektisLijstVerrichtingen.csv"))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    csv.Read();
                    csv.ReadHeader();

                    while (csv.Read())
                    {
                        context.Add(new Treatment { Code = csv.GetField(0), Description = csv.GetField(1), ExplanationRequired = GetBool(csv.GetField(2)) });
                    }

                }
                context.SaveChanges();
            }
        }

        private static bool GetBool(string condition)
        {
            return condition.ToLower() == "ja";
        }
    }
}
