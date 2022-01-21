
using AddressService.Models;
using AddressService.Services.Interfaces;
using AddressService.Models.DTO;
using AddressService.Data;
using AutoMapper;
using AddressService.GeograficCalculations;

namespace AddressService.Services
{
    public class AddressesService : IAddressesService
    {
        private readonly IAddressRepo _addresRepository;
        private readonly IMapper _mapper;
        private readonly IPostCodesIOService _postCodeService;

        public AddressesService(IAddressRepo addressRepository, IMapper mapper, IPostCodesIOService postCodeService)
        {
            _addresRepository = addressRepository;
            _mapper = mapper;
            _postCodeService = postCodeService;
        }

        public IEnumerable<AddressReadDTO> GetLastThreeAddresses()
        {
            var addressesItems = _addresRepository.GetAllAddresses()
                                                    .OrderByDescending(address => address.CreateDate).Take(3);

            return _mapper.Map<IEnumerable<AddressReadDTO>>(addressesItems);
        }
        public async Task<IEnumerable<AddressReadDTO>> GetByPostCode(string postcode)
        {
            var addressItem = _addresRepository.GetAddressByPostcode(postcode);

            if(addressItem.Count() == 0)
            {
                addressItem.Add(await CreateAddress(postcode));
            }

            return _mapper.Map<List<AddressReadDTO>>(addressItem);
        }

        private async Task<Address> CreateAddress(string postcode)
        {
            var addressCreateDTO = await _postCodeService.GetAddressAsync(postcode);
            addressCreateDTO = ComputeDistance(addressCreateDTO);
            var addressModel = _mapper.Map<Address>(addressCreateDTO);
            _addresRepository.CreateAddress(addressModel);
            _addresRepository.SaveChanges();

            return addressModel;
        }

        private AddressCreateDTO ComputeDistance(AddressCreateDTO? addressCreateDTO)
        {
            var coordinates = GenerateCoordinates(addressCreateDTO);
            addressCreateDTO.Distance = CalculateDistance(coordinates);
            return addressCreateDTO;
        }

        private static double CalculateDistance(GeographicCoordinates coordinates) => GeograficCalculation.ComputeDistanceFromLatLonInKm(coordinates);
        
        private GeographicCoordinates GenerateCoordinates(AddressCreateDTO addressCreateDTO)
        {
            var latitudeHeathrowAirporty = 51.4700223;
            var longitudeHeathrowAirporty = -0.4542955;

            return new GeographicCoordinates(addressCreateDTO.Latitude, addressCreateDTO.Longitude, 
                                                latitudeHeathrowAirporty, longitudeHeathrowAirporty);
        }
    }
}
