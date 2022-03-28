namespace RealEstateDemoApp.Services.Addresses
{
    public interface IAddressService
    {
        public int Create(string country, string city, string street
            , string postCode, string neighborhood, int entrance,
            int flat, int allFloor, int floor);
            
    }
}
