using AddressService.HttpClients.Interfaces;
using AddressService.Models.DTO;

namespace AddressService.Services.Interfaces
{
    public interface IPostCodesIOService
    {
        Task<AddressCreateDTO?> GetAddressAsync(string postcode);
    }
}
