using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstateDemoApp.Data.Models
{
    public class Listing
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int SellerId { get; set; }
        public int ListingAddressId { get; set; }
        public decimal Price { get; set; }
        public int PropertyTypeId { get; set; } 
        public string? OutdoorFeatures { get; set; }
        public string? IndoorFeatures { get; set; }
        public string? ClimateControl { get; set; }
        public string? Status { get; set; }
        public int Bedrooms { get; set; }
        public int Bathrooms { get; set; }
        public int ListingTypeId { get; set; }
        public int CarSpaces { get; set; }

        public int LandSize { get; set; }
        
        public PropertyType? PropertyType { get; set; }
        public ListingType? ListingType { get; set; }

        public ListingAddress? ListingAddress { get; set; }
        public List<ListingImage>? Images { get; set; }
    }
}
