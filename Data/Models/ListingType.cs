using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstateDemoApp.Data.Models
{
    public class ListingType
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<Listing>? Listings { get; set; }
    }
}
