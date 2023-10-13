using AutoMapper;
using OceanRestaurant.Dtos.Uploaders;
using OceanRestaurant.Entites;

namespace OceanRestaurant.Api.AutoMapperProfile
{
    public class UploaderImageAutoMapperProfile : Profile
    {
        public UploaderImageAutoMapperProfile()
        {
            CreateMap<UploaderImageDto, DishImage>().ReverseMap();
            CreateMap<UploaderImageDto, GuestImage>().ReverseMap();
        }
    }
}
