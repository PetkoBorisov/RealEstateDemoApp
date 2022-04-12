using Microsoft.EntityFrameworkCore;
using RealEstateDemoApp.Data;
using RealEstateDemoApp.Data.Models;
using System.Linq;

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

            return _data.Listings.Include(x => x.ListingAddress).Include(x => x.Images).Include(x => x.PropertyType).Include(x => x.ListingType).ToList();
        }

        public Listing GetById(int id)
        {
            var data =  _data.Listings.Include(x=>x.Owner).Include(x => x.ListingAddress).Include(x => x.Images).Include(x => x.PropertyType).Include(x => x.ListingType).ToList();
            var result = data.Find(x => x.Id == id);
            return result;

        }




        public ListingsQueryServiceModel All(decimal priceFrom,decimal priceTo,string country,string city,int propertyTypeId, int listingTypeId
            ,string status,int bedrooms,int bathrooms,int carSpaces,List<string> indoorFeatures
            , List<string> outdoorFeatures, List<string> climateControl, int landSizeFrom, int landSizeTo,
            int currentPage,int itemsPerPage,int sortingKey)
        {   
            var modelData = new ListingsQueryServiceModel();
            var data = _data.Listings.Include(x => x.ListingAddress).Include(x=>x.Images).Include(x=>x.PropertyType).Include(x=>x.ListingType).ToList();

            if (sortingKey == 1)
            {
                data = data.OrderBy(x => x.Price).ToList();
            }
            else
          if (sortingKey == 2)
            {
                data = data.OrderByDescending(x => x.Price).ToList();
            }
            else
          if (sortingKey == 3)
            {
                //sort by date
            }
            else
          if (sortingKey == 4)
            {
               //sort by date
            }


            if (priceFrom != 0)
            {
                data = data.Where(x => x.Price >= priceFrom).ToList();

            }

            if(priceTo != 0)
            {
                data = data.Where(x => x.Price <= priceTo).ToList();
            }

            if(!String.IsNullOrWhiteSpace(country))
            {
                data = data.Where(x => x.ListingAddress.Country.Contains(country)).ToList();
            }


            if (!String.IsNullOrWhiteSpace(city))
            {
                data = data.Where(x => x.ListingAddress.City.Contains(city)).ToList();
            }


            if (propertyTypeId != 0)
            {
                data = data.Where(x => x.PropertyTypeId == propertyTypeId).ToList();
            }


            if (listingTypeId != 0)
            {
                data = data.Where(x => x.ListingTypeId == listingTypeId).ToList();
            }

            if (!String.IsNullOrWhiteSpace(status))
            {
                data = data.Where(x => x.Status == status).ToList();
            }

            if(bedrooms != 0)
            {
                data = data.Where(x => x.Bedrooms == bedrooms).ToList();
            }

            if (bathrooms != 0)
            {
                data = data.Where(x => x.Bathrooms == bathrooms).ToList();
            }

            if (carSpaces != 0)
            {
                data = data.Where(x => x.CarSpaces == carSpaces).ToList();
            }

            if(indoorFeatures.Count > 0)
            {
                foreach(var feature in indoorFeatures)
                {
                    data = data.Where(x=>x.IndoorFeatures.Contains(feature)).ToList();
                }

            }

            if (outdoorFeatures.Count > 0)
            {
                foreach (var feature in outdoorFeatures)
                {
                    data = data.Where(x => x.OutdoorFeatures.Contains(feature)).ToList();
                }

            }

            if (climateControl.Count > 0)
            {
                foreach (var feature in climateControl)
                {
                    data = data.Where(x => x.ClimateControl.Contains(feature)).ToList();
                }

            }

            if(landSizeFrom != 0)
            {
                data = data.Where(x => x.LandSize >= landSizeFrom).ToList();
            }

            if(landSizeTo != 0)
            {
                data = data.Where(x => x.LandSize <= landSizeTo).ToList();
            }

            modelData.totalListings = data.Count;
            data = data
               .Skip((currentPage - 1) * itemsPerPage)
               .Take(itemsPerPage).ToList();


          


            modelData.Listings = data;

            return modelData;
        }

        public int Create(string ownerId, int listingAddressId, decimal price,
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
                OwnerId = ownerId,
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



        public void Update(int id,int listingAddressId, decimal price,
            int propertyTypeId, string outdoorFeatures, string indoorFeatures,
            string climateControl, string status, string description, int bedrooms,
            int bathrooms, int listingTypeId, int carSpaces,
            int landSize, List<string> imageUrls)
        {

            var listing = GetById(id);
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






            listing.ListingAddressId = listingAddressId;
            listing.Price = price;
            listing.PropertyTypeId = propertyTypeId;
            listing.OutdoorFeatures = outdoorFeatures;
            listing.IndoorFeatures = indoorFeatures;
            listing.ClimateControl = climateControl;
            listing.Status = status;
            listing.Bedrooms = bedrooms;
            listing.Bathrooms = bathrooms;
            listing.ListingTypeId = listingTypeId;
            listing.CarSpaces = carSpaces;
            listing.LandSize = landSize;
            listing.Images = images;
            listing.Description = description;
            

            
            _data.SaveChanges();


        }



        public void Delete(int id)
        {
            var listing = GetById(id);
            _data.Remove(listing);
            _data.SaveChanges(true);
        }

    }
}
