namespace RealEstateDemoApp.Models.Listings
{
    public class DetailsListingModel
    {
        public List<string> imgUrls { get; set; }
        public string? Country { get; set; }

        public string? City { get; set; }

        public string? Street { get; set; }

        public string? Neighborhood { get; set; }

        public string? PostCode { get; set; }

        public string? Description { get; set; }

        public decimal? Price { get; set; }

        public int Bedrooms { get; set; }
        public int Bathrooms { get; set; }

        public int CarSpaces { get; set; }

        public int LandSize { get; set; }

        public string? PropertyType { get; set; }

        public string? ListingType { get; set; }


        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? UserName { get; set; }



        //put these in seperate model
        public string? From { get; set; }
        public string? To { get; set; }
        public string? Title { get; set; }
        public string? Body { get; set; }


        public List<string> OutdoorFeatures { get; set; }
        public List<string> IndoorFeatures { get; set; }
        public List<string> ClimateControl { get; set; }
    }
}
