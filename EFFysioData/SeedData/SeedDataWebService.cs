using Core.DomainModel;
using CsvHelper;
using EFFysioData.DAL;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Globalization;

namespace EFFysioData.SeedData
{
    public class SeedDataWebService
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            // TOOD: meuh, doesn't work.
            FysioCodeDbContext context = app.ApplicationServices
                .CreateScope().ServiceProvider.GetRequiredService<FysioCodeDbContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            if (!context.Diagnoses.Any())
            {
                using (var reader = new StreamReader("Files\\VektisLijstDiagnoses.csv", System.Text.Encoding.UTF8))
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
                using (var reader = new StreamReader("Files\\VektisLijstVerrichtingen.csv", System.Text.Encoding.UTF8))
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
