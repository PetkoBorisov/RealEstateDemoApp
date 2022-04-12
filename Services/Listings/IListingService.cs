using RealEstateDemoApp.Data.Models;

namespace RealEstateDemoApp.Services.Listings
{
    public interface IListingService
    {
        int Create(
            string sellerId,
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

        void Update(int id,
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

        void Delete(int id);

        ListingsQueryServiceModel All(decimal priceFrom,decimal priceTo,string country,string city,int propertyTypeId,int listingTypeId
            , string status, int bedrooms, int bathrooms, int carSpaces
            , List<string> indoorFeatures, List<string> outdoorFeatures, List<string> climateControl,int landSizeFrom, int landSizeTo,
            int currentPage,int itemsPerPage,int sortingKey);

        List<Listing> All();

        Listing GetById(int id);

    }
}


