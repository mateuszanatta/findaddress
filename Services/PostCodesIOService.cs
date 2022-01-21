using AddressService.Services.Interfaces;
using System.Text.Json;
using AddressService.HttpClients.Interfaces;
using AddressService.Models.DTO;

namespace AddressService.Services
{
    public class PostCodesIOService : IPostCodesIOService
    {

        const string BaseUrl = "http://api.postcodes.io/postcodes/";
        private readonly IHttpClients _httpClient;

        public PostCodesIOService(IHttpClients httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<AddressCreateDTO?> GetAddressAsync(string postcode)
        {
            _httpClient.Clear();
            _httpClient.Add(mediaType: "application/json");
            var urlCall = BaseUrl + postcode;
            var resultStream = await _httpClient.GetStreamAsync(urlCall);
            PostCodesIODTO addressResult = await JsonSerializer.DeserializeAsync<PostCodesIODTO>(resultStream);
            return addressResult?.AddressCreate;
        }
    }
}
