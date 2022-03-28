using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstateDemoApp.Data.Models
{
    public class ListingAddress
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Country { get; set; }
        public string? City { get; set; }
        public string? Street { get; set; }
        public string? PostCode { get; set; }
        public string? Neighborhood { get; set; }
        public int? Entrance { get; set; }
        public int? Flat { get; set; }
        public int? AllFloor { get; set; }
        public int? Floor { get; set; }

        public override string ToString()
        {
            return $"{Country}, {City}, {Neighborhood}, {Street}, {PostCode}";
        }
    }
}
