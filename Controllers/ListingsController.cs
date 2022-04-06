using Microsoft.AspNetCore.Mvc;
using RealEstateDemoApp.Models.Listings;
using RealEstateDemoApp.Services.Addresses;
using RealEstateDemoApp.Services.Listings;
using System.Linq;

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
            ListingFormModel data = new ListingFormModel();
            return View(data);
        }


        [HttpPost]
        public IActionResult Add(ListingFormModel data)
        {
            var test = data.IndoorFeatures.Where(x => x.isSelected).ToList();


            var images = data.Images.Split(", ", StringSplitOptions.RemoveEmptyEntries).ToList();
            var indoors = String.Join(", ", data.IndoorFeatures.Select(x => x.Value).ToArray());
            var outdoors = String.Join(", ", data.OutdoorFeatures.Select(x => x.Value).ToArray());
            var climate = String.Join(", ", data.ClimateControl.Select(x => x.Value).ToArray());
            var listingAddressId = this._address.Create(data.Country, data.City, data.Street, data.PostCode, data.Neighborhood
                , data.Entrance, data.Flat, data.AllFloors, data.Floor);

            var listingId = this._listings.Create('0', listingAddressId, data.Price, data.PropertyTypeId,
                outdoors,indoors, climate,data.Status, data.Description, data.Bedrooms, data.Bathrooms, data.ListingTypeId,
                data.CarSpaces, data.LandSize, images);



            return RedirectToAction("All","Listings");
        }


        public IActionResult All([FromQuery]AllListingsQueryModel modelData)
        {
          
            var indoors = modelData.IndoorFeatures.Where(x=>x.isSelected).Select(x=>x.Value).ToList();
            var outdoors = modelData.OutdoorFeatures.Where(x => x.isSelected).Select(x => x.Value).ToList();
            var climate = modelData.ClimateControl.Where(x => x.isSelected).Select(x => x.Value).ToList();
            var data = _listings.All(modelData.PriceFrom,modelData.PriceTo,modelData.Country,modelData.City,modelData.PropertyTypeId,
                modelData.ListingTypeId,modelData.Status,modelData.Bedrooms,modelData.Bathrooms,modelData.CarSpaces,
                indoors,outdoors,climate,modelData.LandSizeFrom,modelData.LandSizeTo);
            modelData.Listings = data;
            return View(modelData);
        }
    }
}
