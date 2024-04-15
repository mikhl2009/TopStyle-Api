using Microsoft.EntityFrameworkCore;
using TopStyle_Api.Data.Interfaces;
using TopStyle_Api.Domain.DTO;
using TopStyle_Api.Domain.Entities;

namespace TopStyle_Api.Data.Repos
{
    public class OrderRepo : IOrderRepo
    {
        private readonly TopStyleDbContext _context;

        public OrderRepo(TopStyleDbContext context)
        {
            _context = context;
        }

        public async Task CreateOrder(Order order)
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
        }

        public async Task<List<OrderDetail>> GetOrderDetailsByOrderId(int orderId)
        {
            return await _context.OrderDetails
            .Where(od => od.OrderId == orderId)
            .Include(od => od.Product)  // Ensure you include Product if you want to display product details.
            .ToListAsync();
        }
    }
}
