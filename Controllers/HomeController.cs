﻿using Microsoft.AspNetCore.Mvc;
using RealEstateDemoApp.Models;
using RealEstateDemoApp.Models.Features;
using RealEstateDemoApp.Models.Listings;
using RealEstateDemoApp.Services.Listings;
using System.Diagnostics;

namespace RealEstateDemoApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        IListingService _listings;

        public HomeController(IListingService listings)
        {
               _listings = listings;
        }

        public IActionResult Index([FromQuery] AllListingsQueryModel modelData)
        {
            var indoors = modelData.IndoorFeatures.Where(x => x.isSelected).Select(x => x.Value).ToList();
            var outdoors = modelData.OutdoorFeatures.Where(x => x.isSelected).Select(x => x.Value).ToList();
            var climate = modelData.ClimateControl.Where(x => x.isSelected).Select(x => x.Value).ToList();
            var data = _listings.All(modelData.PriceFrom, modelData.PriceTo, modelData.Country, modelData.City, modelData.PropertyTypeId,
                modelData.ListingTypeId, modelData.Status, modelData.Bedrooms, modelData.Bathrooms, modelData.CarSpaces,
                indoors, outdoors, climate, modelData.LandSizeFrom, modelData.LandSizeTo,modelData.currentPage, AllListingsQueryModel.ItemsPerPage);
            modelData.Listings = data.Listings;
          
           

            List<IndexModel> viewModels = new List<IndexModel>();
            for (var i = 0; i < 3; i++)
            {
                viewModels.Add(new IndexModel
                {
                    imgUrl = data.Listings[i].Images.FirstOrDefault().Url,
                    Country = data.Listings[i].ListingAddress.Country,
                    City = data.Listings[i].ListingAddress.City,
                    Street = data.Listings[i].ListingAddress.Street,
                    PostCode = data.Listings[i].ListingAddress.PostCode,
                    Neighborhood = data.Listings[i].ListingAddress.Neighborhood,
                    Price = data.Listings[i].Price

                });
              
            }
            modelData.cauroselItems = viewModels;


            if (modelData == null)
            {
                return View(new AllListingsQueryModel());
            }

            return View(modelData);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}