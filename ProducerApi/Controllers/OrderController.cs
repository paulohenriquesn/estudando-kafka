using Microsoft.AspNetCore.Mvc;
using ProducerApi.Controllers.DTOs;
using ProducerApi.Services;
using System.Text.Json;

namespace ProducerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        public IOrderService _orderService { get; set; }

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public IActionResult CreateOrder([FromBody] CreateOrderDTO dto)
        {

            this._orderService.ProcessOrder(dto.Items);

            return Ok(JsonSerializer.Serialize(dto));
        }
    }
}
