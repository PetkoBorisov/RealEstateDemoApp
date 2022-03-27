namespace RealEstateDemoApp.Data.Models
{
    public class PropertyType
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Listing> Listings { get; set; }

    }
}
