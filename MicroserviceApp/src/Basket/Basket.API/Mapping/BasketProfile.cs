using AutoMapper;
using Basket.API.Entities;
using EventBusRabbitMQ.Events;

namespace Basket.API.Mapping
{
    public class BasketProfile : Profile
    {
        public BasketProfile()
        {
            CreateMap<BasketCheckout, BasketCheckoutEvent>().ReverseMap();
        }
    }
}
