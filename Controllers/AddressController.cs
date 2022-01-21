using Microsoft.AspNetCore.Mvc;
using AddressService.Models.DTO;
using AddressService.Services.Interfaces;

namespace AddressService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AddressController : ControllerBase
    {
        private readonly IAddressesService _addressService;

        public AddressController(IAddressesService addressService)
        {
            _addressService = addressService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<AddressReadDTO>> GetLastThreeAddresses()
        {
            try{
                var address = _addressService.GetLastThreeAddresses();
                
                if(address.Count() == 0) return NotFound();
                
                return Ok(address);
            }
            catch(Exception ex)
            {
                return NotFound(); 
            }
        }

        [HttpGet("{postcode}", Name = "GetAddressByPostCode")]
        public async Task<ActionResult<IEnumerable<AddressReadDTO>>> GetAddressByPostCode(string postcode)
        {
            try{
                var addressItem = await _addressService.GetByPostCode(postcode);

                return Ok(addressItem);
            }
            catch(Exception ex)
            {
                return NotFound();
            }
        }
    }
}