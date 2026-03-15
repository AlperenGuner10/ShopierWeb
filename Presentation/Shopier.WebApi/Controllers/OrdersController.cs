using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shopier.Application.Dtos.OrderDtos;
using Shopier.Application.Usecases.OrderServices;

namespace Shopier.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class OrdersController : ControllerBase
	{
		private readonly IOrderServices _orderServices;

		public OrdersController(IOrderServices orderServices)
		{
			_orderServices=orderServices;
		}
		[HttpGet]
		public async Task<IActionResult> GetAllOrder()
		{
			var values = await _orderServices.GetAllOrderAsync();
			return Ok(values);
		}
		[HttpGet("{id}")]
		public async Task<IActionResult> GetByIdOrder(int id)
		{
			var values = await _orderServices.GetByIdOrderAsync(id);
			return Ok(values);
		}
		[HttpPost]
		public async Task<IActionResult> CreateOrder(CreateOrderDto createOrderDto)
		{
			await _orderServices.CreateOrderAsync(createOrderDto);
			return Ok("Siparişiniz Başarılı Bir Şekilde Oluşturuldu.");
		}
		[HttpPut]
		public async Task<IActionResult> UpdateOrder(UpdateOrderDto updateOrderDto)
		{
			await _orderServices.UpdateOrderAsync(updateOrderDto);
			return Ok("Siparişiniz Başarılı Bir Şekilde Güncellendi.");
		}
		[HttpDelete]
		public async Task<IActionResult> DeleteOrder(int id)
		{
			await _orderServices.DeleteOrderAsync(id);
			return Ok("Siparişiniz Başarılı Bir Şekilde Silindi");
		}
	}
}
