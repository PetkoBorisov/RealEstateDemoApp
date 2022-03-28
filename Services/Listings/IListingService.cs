namespace RealEstateDemoApp.Services.Listings
{
    public interface IListingService
    {
        void Create(
            int sellerId,
            int listingAddressId,
            decimal price,
            int propertyTypeId,
            string outdoorFeatures,
            string indoorFeatures,
            string climateControl,
            string status,
            int bedrooms,
            int bathrooms,
            int listingTypeId,
            int carSpaces,
            int landSize,
            List<string> imageUrls
            );
    }
}


