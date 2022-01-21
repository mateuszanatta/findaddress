using System.ComponentModel.DataAnnotations;

namespace AddressService.Models
{
    public class Address
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public string Postcode { get; set; }

        [Required]
        public string Latitude { get; set; }

        [Required]
        public string Longitude { get; set; }

        public string Country { get; set; }

        public string Parish { get; set; }

        public string AdminDistrict { get; set; }

        public string Region { get; set; }

        public string ParliamentaryConstituency { get; set; }

        [Required]
        public string Distance { get; set; }

        [Required]
        public DateTime CreateDate { get; set; }
    }
}
