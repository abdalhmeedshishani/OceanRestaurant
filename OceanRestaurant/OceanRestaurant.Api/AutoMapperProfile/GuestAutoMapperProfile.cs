using AutoMapper;
using OceanRestaurant.Dtos.Guests;
using OceanRestaurant.Entites;

namespace OceanRestaurant.Api.AutoMapperProfile
{
    public class GuestAutoMapperProfile : Profile
    {

        public GuestAutoMapperProfile()
        {

            CreateMap<Guest , GuestDto>().ReverseMap();
            CreateMap<Guest , GuestDetailsDto>();
            CreateMap<Guest , GuestListDto>();


        }


    }
}
