using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstateDemoApp.Data.Models
{
    public class ListingImage
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Url { get; set; }
        public int ListingId { get; set; }
        public Listing? Listing { get; set; }
    }
}
