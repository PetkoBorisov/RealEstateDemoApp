using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RealEstateDemoApp.Data.Models;

namespace RealEstateDemoApp.Data
{
    public class RealEstateDbContext : IdentityDbContext
    {
        public RealEstateDbContext(DbContextOptions<RealEstateDbContext> options)
            : base(options)
        {
        }


        public DbSet<Listing> Listings { get; set; }
        public DbSet<ListingAddress> ListingAddresses { get; set; }
        public DbSet<ListingImage> ListingImages { get; set; }
        public DbSet<ListingType> ListingTypes { get; set; }
        public DbSet<PropertyType> PropertyTypes { get; set; }
    }
}