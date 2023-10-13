using AutoMapper;
using OceanRestaurant.Dtos.Dishes;
using OceanRestaurant.Entites;

namespace OceanRestaurant.Api.AutoMapperProfile
{
    public class DishAutoMapperProfile : Profile
    {

        public DishAutoMapperProfile()
        {

            CreateMap<Dish, DishDto>().ReverseMap();
            CreateMap<Dish, DishListDto>();
            CreateMap<Dish, DishDetailsDto>();

        }


    }
}
