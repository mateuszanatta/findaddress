using System.Text.Json.Serialization;

namespace AddressService.Models.DTO
{
    public class PostCodesIODTO
    {
        [JsonPropertyName("result")]
        public AddressCreateDTO AddressCreate { get; set; }
    }
}
