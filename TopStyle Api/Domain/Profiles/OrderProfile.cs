using AutoMapper;
using TopStyle_Api.Domain.DTO;
using TopStyle_Api.Domain.Entities;

namespace TopStyle_Api.Domain.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, CreateOrderDto>();
            CreateMap<CreateOrderDto, Order>();
        }

    }
}
