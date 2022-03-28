using RealEstateDemoApp.Data.Models;

namespace RealEstateDemoApp.Services.Listings
{
    public class ListingService : IListingService
    {
        public void Create(int sellerId, int listingAddressId, decimal price,
            int propertyTypeId, string outdoorFeatures, string indoorFeatures,
            string climateControl, string status, int bedrooms,
            int bathrooms, int listingTypeId, int carSpaces,
            int landSize, List<string> imageUrls)
        {
            List<ListingImage> images = new();
           foreach(var url in imageUrls)
           {
                images.Add(new ListingImage {
                    Url = url,
                });

           }

            var data = new Listing
            {
                SellerId = sellerId,
                ListingAddressId = listingAddressId,
                Price = price,
                PropertyTypeId = propertyTypeId,
                OutdoorFeatures = outdoorFeatures,
                IndoorFeatures = indoorFeatures,
                ClimateControl = climateControl,
                Status = status,
                Bedrooms = bedrooms,
                Bathrooms = bathrooms,
                ListingTypeId = listingTypeId,
                CarSpaces = carSpaces,
                LandSize = landSize,
                Images = images
            };
        }
    }
}
