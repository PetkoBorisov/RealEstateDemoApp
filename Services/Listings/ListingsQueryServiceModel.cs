using RealEstateDemoApp.Data.Models;

namespace RealEstateDemoApp.Services.Listings
{
    public class ListingsQueryServiceModel
    {


        public int totalListings { get; set; }

        public List<Listing> Listings { get; set; }
    }
}
