namespace AddressService.Models.DTO
{
    public class AddressReadDTO
    {
        public int Id { get; set; }
        public string Postcode { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Country { get; set; }
        public string Parish { get; set; }
        public string AdminDistrict { get; set; }
        public string Region { get; set; }
        public string ParliamentaryConstituency { get; set; }
        public string Distance { get; set; }
    }
}
