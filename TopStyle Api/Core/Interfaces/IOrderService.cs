using Microsoft.AspNetCore.SignalR;
using TopStyle_Api.Domain.DTO;
using TopStyle_Api.Domain.Entities;

namespace TopStyle_Api.Core.Interfaces
{
    public interface IOrderService
    {
        Task CreateOrder(CreateOrderDto createOrderDto, string userId);
        //Task<List<OrderDetail>> GetOrderDetailsByOrderId(int orderId);
        Task<List<OrderDetail>> GetOrderDetailsByOrderId(int orderId);
    }
}
