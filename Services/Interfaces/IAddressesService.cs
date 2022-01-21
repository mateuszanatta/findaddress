
using AddressService.Models.DTO;

namespace AddressService.Services.Interfaces
{
    public interface IAddressesService
    {
        IEnumerable<AddressReadDTO> GetLastThreeAddresses();
        Task<IEnumerable<AddressReadDTO>> GetByPostCode(string postcode);
    }
}
