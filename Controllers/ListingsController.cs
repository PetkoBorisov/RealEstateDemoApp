using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RealEstateDemoApp.Models.Features;
using RealEstateDemoApp.Models.Listings;
using RealEstateDemoApp.Services.Addresses;
using RealEstateDemoApp.Services.Listings;

using System.Linq;
using System.Security.Claims;

namespace RealEstateDemoApp.Controllers
{
    public class ListingsController : Controller
    {
        IListingService _listings;
        IAddressService _address;
        public UserManager<IdentityUser> _user;

        public ListingsController(IListingService listings,
            IAddressService address, UserManager<IdentityUser> user)
        {
            this._listings = listings;
            this._address = address;
            this._user = user;
        }

        [Authorize]
        public IActionResult Add()
        {
            ListingFormModel data = new ListingFormModel();
            return View(data);
        }


        public IActionResult Details(int id)
        {
            var listing = _listings.GetById(id);

            var modelData = new DetailsListingModel
            {
                City = listing.ListingAddress.City,
                Country = listing.ListingAddress.Country,
                Neighborhood = listing.ListingAddress.Neighborhood,
                PostCode = listing.ListingAddress.PostCode,
                imgUrls = listing.Images.Select(x => x.Url).ToList(),
                Price = listing.Price,
                Street = listing.ListingAddress.Street,
                Description = listing.Description,
                PropertyType = listing.PropertyType.Name,
                ListingType = listing.ListingType.Name,
                IndoorFeatures = listing.IndoorFeatures.Split(",", StringSplitOptions.RemoveEmptyEntries).ToList(),
                OutdoorFeatures = listing.OutdoorFeatures.Split(",", StringSplitOptions.RemoveEmptyEntries).ToList(),
                ClimateControl = listing.ClimateControl.Split(",", StringSplitOptions.RemoveEmptyEntries).ToList(),
                LandSize = listing.LandSize,
                CarSpaces = listing.CarSpaces,
                Bathrooms = listing.Bathrooms,
                Bedrooms = listing.Bedrooms,
                UserName = listing.Owner.UserName,
                Email = listing.Owner.Email,
                PhoneNumber = listing.Owner.PhoneNumber


            };
            return View(modelData);
        }




        [HttpPost]
        public IActionResult Add(ListingFormModel data)
        {
            var test = data.IndoorFeatures.Where(x => x.isSelected).ToList();
            var ownerId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var images = data.Images.Split(",", StringSplitOptions.RemoveEmptyEntries).ToList();
            var indoors = String.Join(",", data.IndoorFeatures.Where(x => x.isSelected).Select(x => x.Value).ToArray());
            var outdoors = String.Join(",", data.OutdoorFeatures.Where(x => x.isSelected).Select(x => x.Value).ToArray());
            var climate = String.Join(",", data.ClimateControl.Where(x => x.isSelected).Select(x => x.Value).ToArray());
            var listingAddressId = this._address.Create(data.Country, data.City, data.Street, data.PostCode, data.Neighborhood
                , data.Entrance, data.Flat, data.AllFloors, data.Floor);

            var listingId = this._listings.Create(ownerId, listingAddressId, data.Price, data.PropertyTypeId,
                outdoors, indoors, climate, data.Status, data.Description, data.Bedrooms, data.Bathrooms, data.ListingTypeId,
                data.CarSpaces, data.LandSize, images);



            return RedirectToAction("All", "Listings");
        }
        


        public IActionResult All([FromQuery] AllListingsQueryModel modelData)
        {

            var indoors = modelData.IndoorFeatures.Where(x => x.isSelected).Select(x => x.Value).ToList();
            var outdoors = modelData.OutdoorFeatures.Where(x => x.isSelected).Select(x => x.Value).ToList();
            var climate = modelData.ClimateControl.Where(x => x.isSelected).Select(x => x.Value).ToList();


            var dict = new Dictionary<string, string>();
            this.Request.Query.ToList().ForEach(x => dict.Add(x.Key, x.Value));

        
            foreach (var param in dict)
            {
                if (param.Value == "true,false")
                {
                    dict[param.Key] = "true";
                }

            }

            modelData.queryDict = dict;



            if (modelData.currentPage < 1)
            {
                modelData.currentPage = 1;
            }








            var data = _listings.All(modelData.PriceFrom, modelData.PriceTo, modelData.Country, modelData.City, modelData.PropertyTypeId,
                modelData.ListingTypeId, modelData.Status, modelData.Bedrooms, modelData.Bathrooms, modelData.CarSpaces,
                indoors, outdoors, climate, modelData.LandSizeFrom, modelData.LandSizeTo, modelData.currentPage, AllListingsQueryModel.ItemsPerPage, modelData.SortingKey);
            modelData.Listings = data.Listings;

            modelData.totalPages = Math.Ceiling((double)data.totalListings / AllListingsQueryModel.ItemsPerPage);

            if (modelData.totalPages < 1)
            {
                modelData.totalPages = 1;
            }


            ViewBag.Id = _user.GetUserId(this.User);


            return View(modelData);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Edit(int id,ListingFormModel data)
        {
            
            var images = data.Images.Split(",", StringSplitOptions.RemoveEmptyEntries).ToList();
            var indoors = String.Join(",", data.IndoorFeatures.Where(x => x.isSelected).Select(x => x.Value).ToArray());
            var outdoors = String.Join(",", data.OutdoorFeatures.Where(x => x.isSelected).Select(x => x.Value).ToArray());
            var climate = String.Join(",", data.ClimateControl.Where(x => x.isSelected).Select(x => x.Value).ToArray());
            var listingAddressId = this._address.Create(data.Country, data.City, data.Street, data.PostCode, data.Neighborhood
                , data.Entrance, data.Flat, data.AllFloors, data.Floor);

            this._listings.Update(id, listingAddressId, data.Price, data.PropertyTypeId,
                outdoors, indoors, climate, data.Status, data.Description, data.Bedrooms, data.Bathrooms, data.ListingTypeId,
                data.CarSpaces, data.LandSize, images);



            return RedirectToAction("All", "Listings");
        }


        public IActionResult Delete(int id)
        {
            _listings.Delete(id);
            return RedirectToAction("All", "Listings");
        }


        [Authorize]
        public IActionResult Edit(int id)
        {
          
            var listing = _listings.GetById(id);
            var indoors = listing.IndoorFeatures.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList();
            var outdoors = listing.OutdoorFeatures.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList();
            var climate = listing.ClimateControl.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList();





            ListingFormModel formModel = new ListingFormModel {
                PropertyTypeId = listing.PropertyTypeId,
                ListingTypeId = listing.ListingTypeId,
                Images = String.Join(",",listing.Images.Select(x=>x.Url)),
                Status = listing.Status,
                Description = listing.Description,
                Bedrooms = listing.Bedrooms,
                Bathrooms = listing.Bathrooms,
                CarSpaces = listing.CarSpaces,
                LandSize = listing.LandSize,
                Price = listing.Price,
                Country = listing.ListingAddress.Country,
                City = listing.ListingAddress.City,
                Street = listing.ListingAddress.Street,
                PostCode = listing.ListingAddress.PostCode,
                Neighborhood = listing.ListingAddress.Neighborhood,
                Entrance = (int)listing.ListingAddress.Entrance,
                Flat = (int)listing.ListingAddress.Flat,
                AllFloors = (int)listing.ListingAddress.AllFloor,
                Floor = (int)listing.ListingAddress.Floor,
                
            };


            formModel.IndoorFeatures.ForEach(x => {
                if (indoors.Contains(x.Value))
                {
                    x.isSelected = true;
                }
            });


            formModel.OutdoorFeatures.ForEach(x => {
                if (outdoors.Contains(x.Value))
                {
                    x.isSelected = true;
                }
            });


            formModel.ClimateControl.ForEach(x => {
                if (climate.Contains(x.Value))
                {
                    x.isSelected = true;
                }
            });

            return View(formModel);
        }



    }
}
