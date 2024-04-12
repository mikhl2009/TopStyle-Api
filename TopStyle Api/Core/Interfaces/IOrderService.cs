using TopStyle_Api.Domain.Entities;

namespace TopStyle_Api.Core.Interfaces
{
    public interface IOrderService
    {
        Task CreateOrder(Order order);
    }
}
