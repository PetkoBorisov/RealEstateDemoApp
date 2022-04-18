using Microsoft.AspNetCore.Mvc;
using RealEstateDemoApp.Models.Features;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace RealEstateDemoApp.Models.Listings
{
    public class ListingFormModel
    {
        public ListingFormModel()
        {
            this.OutdoorFeatures = FeaturesFeeder.feedOutdoorFeatures();

            this.IndoorFeatures = FeaturesFeeder.feedIndoorFeatures();

            this.ClimateControl = FeaturesFeeder.feedClimateFeatures();
    
        }
        [Required]
        public int PropertyTypeId { get; set; }
        [Required]
        public int ListingTypeId { get; set; }
       
        public List<FeatureModel>? OutdoorFeatures { get; set; }
        public List<FeatureModel>? IndoorFeatures { get; set; }
        [Required]
        public string Images { get; set; }
        public List<FeatureModel>? ClimateControl { get; set; }
        [Required]
        public string? Status { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        public int Bedrooms { get; set; }
        [Required]
        public int Bathrooms { get; set; }
        [Required]
        public int CarSpaces { get; set; }
        [Required]
        public int LandSize { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public string? Country { get; set; }
        [Required]
        public string? City { get; set; }
        [Required]
        public string? Street { get; set; }
        [Required]
        public string? PostCode { get; set; }
        [Required]
        public string? Neighborhood { get; set; }
        [Required]
        public int Entrance { get; set; }
        [Required]
        public int Flat { get; set; }
        [Required]
        public int AllFloors { get; set; }
        [Required]
        public int Floor { get; set; }
        
        

    }
}
