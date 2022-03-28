using RealEstateDemoApp.Data;
using RealEstateDemoApp.Data.Models;

namespace RealEstateDemoApp.Services.Addresses
{
    public class AddressService : IAddressService
    {
        private readonly RealEstateDbContext _data;

        public AddressService(RealEstateDbContext data)
        {
            this._data = data;
        }

        public int Create(string country, string city, string street, string postCode, string neighborhood, int entrance, int flat, int floor, int allFloor)
        {
            var address = new ListingAddress {
                Country = country,
                City = city,
                Street = street,
                PostCode = postCode,
                Neighborhood = neighborhood,
                Entrance = entrance,
                Flat = flat,
                Floor = floor,
                AllFloor = allFloor

            };
            this._data.ListingAddresses.Add(address);
            this._data.SaveChanges();
            return address.Id;
        }
    }
}
