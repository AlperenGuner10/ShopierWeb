using Shopier.Application.Dtos.ProductDtos;
using Shopier.Application.Interfaces;
using Shopier.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopier.Application.Usecases.ProductServices
{
	public class ProductService : IProductServices
	{
		private readonly IRepository<Product> _repository;

		public ProductService(IRepository<Product> repository)
		{
			_repository=repository;
		}

		public async Task CreateProductAsync(CreateProductDto model)
		{
			await _repository.CreateAsync(new Product
			{
				ProductName = model.ProductName,
				Description = model.Description,
				ImageUrl = model.ImageUrl,
				Price = model.Price,
				Stock = model.Stock,
				CategoryId = model.CategoryId
			});
		}

		public async Task DeleteProductAsync(int id)
		{
			var values = await _repository.GetByIdAsync(id);
			await _repository.DeleteAsync(values);
		}

		public async Task<List<ResultProductDto>> GetAllProductAsync()
		{
			var values = await _repository.GetAllAsync();
			return values.Select(x => new ResultProductDto
			{
				ProductId = x.ProductId,
				ProductName = x.ProductName,
				Description = x.Description,
				ImageUrl = x.ImageUrl,
				Price = x.Price,
				Stock = x.Stock,
				CategoryId = x.CategoryId
			}).ToList();
		}

		public async Task<GetByIdProductDto> GetByIdProductAsync(int id)
		{
			var values = await _repository.GetByIdAsync(id);
			var result = new GetByIdProductDto
			{
				ProductId = values.ProductId,
				ProductName = values.ProductName,
				Description = values.Description,
				ImageUrl = values.ImageUrl,
				Price = values.Price,
				Stock = values.Stock,
				CategoryId = values.CategoryId
			};
			return result;
		}

		public async Task UpdateProductAsync(UpdateProductDto model)
		{
			var values = await _repository.GetByIdAsync(model.ProductId);
			values.ProductName = model.ProductName;
			values.Description = model.Description;
			values.ImageUrl = model.ImageUrl;
			values.Price = model.Price;
			values.Stock = model.Stock;
			values.CategoryId = model.CategoryId;
			await _repository.UpdateAsync(values);
		}
	}
}
