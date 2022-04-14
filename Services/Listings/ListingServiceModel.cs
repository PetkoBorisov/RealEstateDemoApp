namespace RealEstateDemoApp.Services.Listings
{
    public class ListingServiceModel
    {

        public int Id { get; set; }
        public string? OwnerId { get; set; }
        public string? Country { get; set; }
        public string? City { get; set; }
        public string? Street { get; set; }
        public string? PostCode { get; set; }
        public string? Neighborhood { get; set; }
        public int? Entrance { get; set; }
        public int? Flat { get; set; }
        public int? AllFloor { get; set; }
        public int? Floor { get; set; }
        public decimal Price { get; set; }
        public string? PropertyType { get; set; }
        public string? OutdoorFeatures { get; set; }
        public string? IndoorFeatures { get; set; }
        public string? ClimateControl { get; set; }
        public string? Description { get; set; }
        public string? Status { get; set; }
        public int Bedrooms { get; set; }
        public int Bathrooms { get; set; }
        public string? ListingType { get; set; }
        public int CarSpaces { get; set; }

        public int LandSize { get; set; }
        public string Images { get; set; }
        //Do i need a model for the images(ImageServiceModel)??
    }
}
