using Microsoft.EntityFrameworkCore;
using RealEstateDemoApp.Data;
using RealEstateDemoApp.Data.Models;

namespace RealEstateDemoApp.Infrastructure.Extensions
{
    public static class ApplicationBuilderExtension
    {
        public static IApplicationBuilder PrepareDatabase(
           this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();
            var services = serviceScope.ServiceProvider;
            
            MigrateDatabase(services);
            SeedPropertyTypes(services);
            SeedListingTypes(services);
            return app;
        }

        private static void SeedPropertyTypes(IServiceProvider services)
        {
            var data = services.GetRequiredService<RealEstateDbContext>();

            if (data.PropertyTypes.Any())
            {
                return;
            }

            data.PropertyTypes.AddRange(new[]
            {
                new PropertyType { Name = "House" },
                new PropertyType { Name = "Apartment" },
            });

            data.SaveChanges();
        }

        private static void SeedListingTypes(IServiceProvider services)
        {
            var data = services.GetRequiredService<RealEstateDbContext>();

            if (data.ListingTypes.Any())
            {
                return;
            }

            data.ListingTypes.AddRange(new[]
            {
                new ListingType { Name = "Rent" },
                new ListingType { Name = "Sell" }
            });

            data.SaveChanges();
        }



        private static void MigrateDatabase(IServiceProvider services)
        {
            var data = services.GetRequiredService<RealEstateDbContext>();

            data.Database.Migrate();
        }
    }
}
