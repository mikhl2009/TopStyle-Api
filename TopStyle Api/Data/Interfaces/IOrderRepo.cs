using TopStyle_Api.Domain.Entities;

namespace TopStyle_Api.Data.Interfaces
{
    public interface IOrderRepo
    {
        Task CreateOrder(Order order);
    }
}
