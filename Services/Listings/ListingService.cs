using Microsoft.EntityFrameworkCore;
using RealEstateDemoApp.Data;
using RealEstateDemoApp.Data.Models;

namespace RealEstateDemoApp.Services.Listings
{
    public class ListingService : IListingService
    {
        private readonly RealEstateDbContext _data;

        public ListingService(RealEstateDbContext data)
        {
            this._data = data;
        }

        public List<Listing> All()
        {
            return _data.Listings.Include(x => x.ListingAddress).Include(x=>x.Images).ToList();
        }

        public int Create(int sellerId, int listingAddressId, decimal price,
            int propertyTypeId, string outdoorFeatures, string indoorFeatures,
            string climateControl, string status, string description, int bedrooms,
            int bathrooms, int listingTypeId, int carSpaces,
            int landSize, List<string> imageUrls)
        {
            List<ListingImage> images = new();
            if (imageUrls.Any())
            {
                foreach (var url in imageUrls)
                {
                    images.Add(new ListingImage
                    {
                        Url = url,
                    });

                }
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
                Images = images,
                Description = description
            };
            this._data.Listings.Add(data);
            this._data.SaveChanges();
            return data.Id;
        }
    }
}
