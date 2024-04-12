using TopStyle_Api.Domain.Entities;

namespace TopStyle_Api.Domain.DTO
{
    public class CreateOrderDto
    {
        public List<OrderItemDto> Items { get; set; }
    }
}
