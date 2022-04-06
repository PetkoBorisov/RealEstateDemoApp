using Microsoft.AspNetCore.Mvc;
using RealEstateDemoApp.Models.Listings;
using RealEstateDemoApp.Services.Listings;

namespace RealEstateDemoApp.Components
{
    public class SearchFormViewComponent:ViewComponent
    {
        public IListingService _listings;
        public SearchFormViewComponent(IListingService listings)
        {
            _listings = listings;
          
        }

        public async Task<IViewComponentResult> InvokeAsync([FromQuery]AllListingsQueryModel modelData)
        {

           
            return View(modelData);


        }


    }
}
