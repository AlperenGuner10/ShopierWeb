using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shopier.Application.Dtos.CartItemDtos;
using Shopier.Application.Usecases.CartItemsServices;

namespace Shopier.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CartItemsController : ControllerBase
	{
		private readonly ICartItemServices _cartItemServices;

		public CartItemsController(ICartItemServices cartItemServices)
		{
			_cartItemServices=cartItemServices;
		}
		[HttpGet]
		public async Task<IActionResult> GetAllCartItems()
		{
			var values = await _cartItemServices.GetAllCartItemAsync();
			return Ok(values);
		}
		[HttpGet("{id}")]
		public async Task<IActionResult> GetByIdCartItem(int id)
		{
			var value = await _cartItemServices.GetByIdCartItemAsync(id);
			return Ok(value);
		}
		[HttpPost]
		public async Task<IActionResult> CreateCartItem(CreateCartItemDto dto)
		{
			await _cartItemServices.CreateCartItemAsync(dto);
			return Ok("Kart item başarılı bir şekilde oluşturulmuştur");
		}
		[HttpPut]
		public async Task<IActionResult> UpdateCartItemAsync(UpdateCartItemDto dto)
		{
			await _cartItemServices.UpdateCartItemAsync(dto);
			return Ok("Kart item başarılı bir şekilde güncellenmiştir");
		}
		[HttpDelete]
		public async Task<IActionResult> DeleteCartItem(int id)
		{
			await _cartItemServices.DeleteCartItemAsync(id);
			return Ok("Kart item başarılı bir şekilde silinmiştir");
		}
	}
}
