using AddressService.Models;

namespace AddressService.Data
{
    public class AddressRepo : IAddressRepo
    {
        private readonly AppDbContext _context;

        public AddressRepo(AppDbContext context)
        {
            _context = context;
        }

        public void CreateAddress(Address address)
        {
            if(address == null)
            {
                throw new ArgumentNullException(nameof(address));
            }
            address.CreateDate = DateTime.UtcNow;
            _context.Addresses.Add(address);
        }

        public IEnumerable<Address> GetAllAddresses() => _context.Addresses.ToList();

        public List<Address> GetAddressByPostcode(string postcode) => _context.Addresses.Where(p => p.Postcode.Replace(" ", "").Equals(postcode)).ToList();

        public bool SaveChanges() => (_context.SaveChanges() >= 0);
    }
}