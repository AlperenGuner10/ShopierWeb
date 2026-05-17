using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shopier.Application.Dtos.OrderItemDtos;
using Shopier.Application.Usecases.OrderItemItemServices;

namespace Shopier.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class OrderItemsController : ControllerBase
	{
		private readonly IOrderItemItemService _orderItemService;

		public OrderItemsController(IOrderItemItemService orderItemService)
		{
			_orderItemService=orderItemService;
		}
		[HttpGet]
		public async Task<IActionResult> GetAllOrderItem()
		{
			var values = await _orderItemService.GetAllOrderItemAsync();
			return Ok(values);
		}
		[HttpGet("{id}")]
		public async Task<IActionResult> GetByIdOrderItem(int id)
		{
			var values = await _orderItemService.GetByIdOrderItemAsync(id);
			return Ok(values);
		}
		[HttpPost]
		public async Task<IActionResult> CreateOrderItem(CreateOrderItemDto orderItemDto)
		{
			await _orderItemService.CreateOrderItemAsync(orderItemDto);
			return Ok("OrderItem Başarılı Bir Şekilde Oluşturuldu.");
		}
		[HttpPut]
		public async Task<IActionResult> UpdateOrderItem(UpdateOrderItemDto orderItemDto)
		{
			await _orderItemService.UpdateOrderItemAsync(orderItemDto);
			return Ok("OrderItem Başarılı Bir Şekilde Güncellendi.");
		}
		[HttpDelete]
		public async Task<IActionResult> DeleteOrderItem(int id)
		{
			await _orderItemService.DeleteOrderItemAsync(id);
			return Ok("OrderItem Başarılı Bir Şekilde Silindi.");
		}
	}
}
