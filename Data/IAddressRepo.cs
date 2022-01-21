using AddressService.Models;

namespace AddressService.Data
{
    public interface IAddressRepo
    {
        bool SaveChanges();
        IEnumerable<Address> GetAllAddresses();
        List<Address> GetAddressByPostcode(string Postcode);
        void CreateAddress(Address address);
    }
}