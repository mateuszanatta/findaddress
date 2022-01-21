using System.Text.Json.Serialization;

namespace AddressService.Models.DTO
{
    public class AddressCreateDTO
    {
        [JsonPropertyName("postcode")]
        public string Postcode { get; set; }
        
        [JsonPropertyName("latitude")]
        public double Latitude { get; set; }
        
        [JsonPropertyName("longitude")]
        public double Longitude { get; set; }

        [JsonPropertyName("country")]
        public string Country { get; set; }

        [JsonPropertyName("parish")]
        public string Parish { get; set; }

        [JsonPropertyName("admin_district")]
        public string AdminDistrict { get; set; }

        [JsonPropertyName("region")]
        public string Region { get; set; }

        [JsonPropertyName("parliamentary_constituency")]
        public string ParliamentaryConstituency { get; set; }
        public double Distance { get; set; }
    }
}
