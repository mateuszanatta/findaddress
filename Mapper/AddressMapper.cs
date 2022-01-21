using AutoMapper;
using AddressService.Models.DTO;
using AddressService.Models;

namespace AddressService.Mapper
{
    public class AddressMapper : Profile
    {
        public AddressMapper()
        {
            CreateMap<Address, AddressReadDTO>();
            CreateMap<AddressCreateDTO, Address>();
        }
    }
}