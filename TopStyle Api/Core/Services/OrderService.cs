using AutoMapper;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using TopStyle_Api.Core.Interfaces;
using TopStyle_Api.Data.Interfaces;
using TopStyle_Api.Domain.DTO;
using TopStyle_Api.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace TopStyle_Api.Core.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepo _orderRepo;

        public OrderService(IOrderRepo orderRepo)
        {
            _orderRepo = orderRepo;
        }

        public async Task CreateOrder(CreateOrderDto createOrderDto, string userId)
        {
            Order order = new Order
            {
                UserId = userId,
                OrderDate = DateTime.UtcNow,
                OrderDetails = new List<OrderDetail>()
            };

            foreach (var item in createOrderDto.Items)
            {
                OrderDetail detail = new OrderDetail
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity
                };
                order.OrderDetails.Add(detail);
            }

            try
            {
                await _orderRepo.CreateOrder(order);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Failed to create order", ex);
            }
        }

        public async Task<List<OrderDetail>> GetOrderDetailsByOrderId(int orderId)
        {
            return await _orderRepo.GetOrderDetailsByOrderId(orderId);
        }

    }
}
