using Microsoft.AspNetCore.Mvc;
using RealEstateDemoApp.Models.Listings;
using RealEstateDemoApp.Services.Addresses;
using RealEstateDemoApp.Services.Listings;

namespace RealEstateDemoApp.Controllers
{
    public class ListingsController : Controller
    {
        IListingService _listings;
        IAddressService _address;
        public ListingsController(IListingService listings,
            IAddressService address)
        {
            this._listings = listings;
            this._address = address;
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(ListingFormModel data)
        {
            
            var outdoorFeatures = this.Request.Form.Where(x => x.Key == "outdoor").FirstOrDefault();
            var indoorFeatures = this.Request.Form.Where(x => x.Key == "indoor").FirstOrDefault();
            var climateFeatures = this.Request.Form.Where(x => x.Key == "climate").FirstOrDefault();
            data.OutdoorFeatures = outdoorFeatures.Value;
            data.IndoorFeatures = indoorFeatures.Value;
            data.ClimateControl = climateFeatures.Value;
            var images = data.Images.Split(", ", StringSplitOptions.RemoveEmptyEntries).ToList();
            var listingAddressId = this._address.Create(data.Country, data.City, data.Street, data.PostCode, data.Neighborhood
                , data.Entrance, data.Flat, data.AllFloors, data.Floor);
            var listingId = this._listings.Create('0', listingAddressId, data.Price, data.PropertyTypeId, data.OutdoorFeatures
                , data.IndoorFeatures, data.ClimateControl, data.Status, data.Bedrooms, data.Bathrooms, data.ListingTypeId,
                data.CarSpaces, data.LandSize,images);

           

            return View();
        }
    }
}
