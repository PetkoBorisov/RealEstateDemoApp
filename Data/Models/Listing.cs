namespace RealEstateDemoApp.Data.Models
{
    public class Listing
    {
        public int Id { get; set; }
        public int SellerId { get; set; }
        public int AddressId { get; set; }
        public decimal Price { get; set; }
        public string? Title { get; set; }
        public int PropertyTypeId { get; set; } 
        public string? OutdoorFeatures { get; set; }
        public string? IndoorFeatures { get; set; }
        public string? ClimateControl { get; set; }
        public string? Status { get; set; }
        public int Bedrooms { get; set; }
        public int Bathrooms { get; set; }

        public int CarSpaces { get; set; }

        public int LandSize { get; set; }
        
        public PropertyType PropertyType { get; set; }
        public Address Address { get; set; }
    }
}
