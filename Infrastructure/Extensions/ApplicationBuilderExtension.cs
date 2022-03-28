using Microsoft.EntityFrameworkCore;
using RealEstateDemoApp.Data;

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

            return app;
        }

        //private static void SeedCategories(IServiceProvider services)
        //{
        //    var data = services.GetRequiredService<CarRentingDbContext>();

        //    if (data.Categories.Any())
        //    {
        //        return;
        //    }

        //    data.Categories.AddRange(new[]
        //    {
        //        new Category { Name = "Mini" },
        //        new Category { Name = "Economy" },
        //        new Category { Name = "Midsize" },
        //        new Category { Name = "Large" },
        //        new Category { Name = "SUV" },
        //        new Category { Name = "Vans" },
        //        new Category { Name = "Luxury" },
        //    });

        //    data.SaveChanges();
        //}



        private static void MigrateDatabase(IServiceProvider services)
        {
            var data = services.GetRequiredService<RealEstateDbContext>();

            data.Database.Migrate();
        }
    }
}
