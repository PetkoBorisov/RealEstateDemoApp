
using RealEstateDemoApp.Data.Models;
using RealEstateDemoApp.Models.Features;

namespace RealEstateDemoApp.Models.Listings
{
    public class AllListingsQueryModel
    {
        public AllListingsQueryModel()
        {
            this.IndoorFeatures = FeaturesFeeder.feedIndoorFeatures();
            this.OutdoorFeatures = FeaturesFeeder.feedOutdoorFeatures();
            this.ClimateControl = FeaturesFeeder.feedClimateFeatures();
            this.currentPage = 1;
        }
        public static int ItemsPerPage = 3;
        public int PropertyTypeId { get; set; }
        public int ListingTypeId { get; set; }
        public string? Status { get; set; }
        public int Bedrooms { get; set; }
        public int Bathrooms { get; set; }
        public int CarSpaces { get; set; }
        public int LandSizeFrom { get; set; }
        public int LandSizeTo { get; set; }
        public decimal PriceFrom { get; set; }
        public decimal PriceTo { get; set; }
        public string? Country { get; set; }
        public string? City { get; set; }
        public int currentPage { get; set; }
        public double totalPages { get; set; }
        public Dictionary<string,string> queryDict { get; set; }
        public List<FeatureModel> IndoorFeatures { get; set; }
        public List<FeatureModel> OutdoorFeatures { get; set; }
        public List<FeatureModel> ClimateControl { get; set; }

        public List<IndexModel> cauroselItems  { get; set; }
        public List<Listing> Listings { get; set; }
    }
}
