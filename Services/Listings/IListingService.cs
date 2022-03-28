using RealEstateDemoApp.Data.Models;

namespace RealEstateDemoApp.Services.Listings
{
    public interface IListingService
    {
        int Create(
            int sellerId,
            int listingAddressId,
            decimal price,
            int propertyTypeId,
            string outdoorFeatures,
            string indoorFeatures,
            string climateControl,
            string status,
            string description,
            int bedrooms,
            int bathrooms,
            int listingTypeId,
            int carSpaces,
            int landSize,
            List<string> imageUrls
            );

        List<Listing> All();
       
    }
}


