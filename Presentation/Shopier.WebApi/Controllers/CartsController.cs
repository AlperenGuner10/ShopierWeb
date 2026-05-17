using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shopier.Application.Dtos.CartDtos;
using Shopier.Application.Usecases.CartServices;

namespace Shopier.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CartsController : ControllerBase
	{
		private readonly ICartServices _cartServices;

		public CartsController(ICartServices cartServices)
		{
			_cartServices=cartServices;
		}
		[HttpGet]
		public async Task<IActionResult> GetAllCart()
		{
			var values = await _cartServices.GetAllCartAsync();
			return Ok(values);
		}
		[HttpGet("{id}")]
		public async Task<IActionResult> GetByIdCart(int id)
		{
			var values = await _cartServices.GetByIdCartAsync(id);
			return Ok(values);
		}
		[HttpPost]
		public async Task<IActionResult> CreateCart(CreateCartDto dto)
		{
			await _cartServices.CreateCartAsync(dto);
			return Ok("Kartınız başarılı bir şekilde oluşturuldu.");
		}
		[HttpPut]
		public async Task<IActionResult> UpdateCart(UpdateCartDto dto)
		{
			await _cartServices.UpdateCartAsync(dto);
			return Ok("Kartınız başarılı bir şekilde güncellendi");
		}
		[HttpDelete]
		public async Task<IActionResult> DeleteCart(int id)
		{
			await _cartServices.DeleteCartAsync(id);
			return Ok("Kartınız başarılı bir şekilde silinmiştir");
		}
	}
}
