using CsvHelper;
using Fysio_Codes.DAL;
using Fysio_Codes.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Fysio_Codes.SeedData
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {

            FysioCodeDbContext context = app.ApplicationServices
                .CreateScope().ServiceProvider.GetRequiredService<FysioCodeDbContext>();

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
                        context.Add(new Diagnosis { Code = int.Parse(csv.GetField(0)), BodyLocation = csv.GetField(1), Pathology = csv.GetField(2) });
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
