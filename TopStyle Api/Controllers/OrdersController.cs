using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using TopStyle_Api.Core.Interfaces;
using TopStyle_Api.Domain.DTO;
using TopStyle_Api.Domain.Identity;

[Route("api/[controller]")]
[ApiController]
public class OrdersController : ControllerBase
{
    private readonly IOrderService _orderService;
    private readonly ILogger<OrdersController> _logger;

    public OrdersController(IOrderService orderService, ILogger<OrdersController> logger)
    {
        _orderService = orderService;
        _logger = logger;
    }

    [HttpPost("Create")]
    [Authorize] 
    public async Task<IActionResult> Create(CreateOrderDto createOrderDto)
    {
      
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (string.IsNullOrEmpty(userId))
        {
            _logger.LogError("Failed to create order: User ID is missing from the token.");
            return Unauthorized("User ID is missing from the token.");
        }

        try
        {
          
            await _orderService.CreateOrder(createOrderDto, userId);
            return Ok("Order created successfully.");
        }
        catch (InvalidOperationException ex)
        {
            _logger.LogError($"Operation failed: {ex.Message}");
            return BadRequest(ex.Message);
        }
        catch (DbUpdateException ex)
        {
            _logger.LogError($"Database update error: {ex.InnerException?.Message ?? ex.Message}");
            return StatusCode(500, "Error creating order. Please try again.");
        }
        catch (Exception ex)
        {
            _logger.LogError($"Unexpected error: {ex.Message}");
            return StatusCode(500, "An unexpected error occurred.");
        }
    }

    [HttpGet("{orderId}")]
    public async Task<IActionResult> GetOrderDetails(int orderId)
    {
        var orderDetails = await _orderService.GetOrderDetailsByOrderId(orderId);
        if (orderDetails == null || !orderDetails.Any())
            return NotFound("No order details found for the given order ID.");

        return Ok(orderDetails);
    }

}
