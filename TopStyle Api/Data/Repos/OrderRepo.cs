using TopStyle_Api.Data.Interfaces;
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
    }
}
