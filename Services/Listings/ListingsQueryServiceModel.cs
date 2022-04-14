using RealEstateDemoApp.Data.Models;

namespace RealEstateDemoApp.Services.Listings
{
    public class ListingsQueryServiceModel
    {


        public int totalListings { get; set; }

        public List<ListingServiceModel> Listings { get; set; }
    }
}
