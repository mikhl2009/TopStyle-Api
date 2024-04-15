using TopStyle_Api.Domain.DTO;
using TopStyle_Api.Domain.Entities;

namespace TopStyle_Api.Data.Interfaces
{
    public interface IOrderRepo
    {
        Task CreateOrder(Order order);
        Task<List<OrderDetail>> GetOrderDetailsByOrderId(int orderId);
    }
}
