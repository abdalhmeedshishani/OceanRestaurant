using AutoMapper;
using OceanRestaurant.Dtos.Orders;
using OceanRestaurant.Entites;

namespace OceanRestaurant.Api.AutoMapperProfile
{
    public class OrderAutoMapperProfile : Profile
    {

        public OrderAutoMapperProfile()
        {
            CreateMap<Order , OrderDto>().ReverseMap();

            CreateMap<Order , OrderDetailsDto>();

            CreateMap<Order , OrderListDto>();
        }

    }
}
