using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shopier.Application.Dtos.ProductDtos;
using Shopier.Application.Usecases.ProductServices;
using Shopier.Domain.Entities;

namespace Shopier.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductsController : ControllerBase
	{
		private readonly IProductServices _productServices;

		public ProductsController(IProductServices productServices)
		{
			_productServices=productServices;
		}
		[HttpGet]
		public async Task<IActionResult> GetAllProduct()
		{
			var values = await _productServices.GetAllProductAsync();
			return Ok(values);
		}
		[HttpGet("{id}")]
		public async Task<IActionResult> GetByIdProduct(int id)
		{
			var values = await _productServices.GetByIdProductAsync(id);
			return Ok(values);
		}
		[HttpPost]
		public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
		{
			await _productServices.CreateProductAsync(createProductDto);
			return Ok("Product Başarılı Bir Şekilde Eklendi");
		}
		[HttpPut]
		public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
		{
			await _productServices.UpdateProductAsync(updateProductDto);
			return Ok("Product Başarılı Bir Şekilde Güncellendi");
		}
		[HttpDelete]
		public async Task<IActionResult> DeleteProduct(int id)
		{
			await _productServices.DeleteProductAsync(id);
			return Ok("Product Başarılı Bir Şekilde Silindi."); 
		}
	}
}
