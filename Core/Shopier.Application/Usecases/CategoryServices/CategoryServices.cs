using Shopier.Application.Dtos.CategoryDtos;
using Shopier.Application.Interfaces;
using Shopier.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopier.Application.Usecases.CategoryServices
{
	public class CategoryServices : ICategoryServices
	{
		private readonly IRepository<Category> _repository;

		public CategoryServices(IRepository<Category> repository)
		{
			_repository=repository;
		}

		public async Task CreateCategoryAsync(CreateCategoryDto model)
		{
			await _repository.CreateAsync(new Category
			{
				CategoryName = model.CategoryName,
			});
		}

		public async Task DeleteCategoryAsync(int id)
		{
			var category = await _repository.GetByIdAsync(id);
			await _repository.DeleteAsync(category);
		}

		public async Task<List<ResultCategoryDto>> GetAllCategoryAsync()
		{
			var category = await _repository.GetAllAsync();
			return category.Select(x => new ResultCategoryDto
			{
				CategoryId = x.CategoryId,
				CategoryName = x.CategoryName
			}).ToList();
		}

		public async Task<GetByIdCategory> GetByIdCategoryAsync(int id)
		{
			var category = await _repository.GetByIdAsync(id);
			var newCategory = new GetByIdCategory
			{
				CategoryId = category.CategoryId,
				CategoryName = category.CategoryName
			};
			return newCategory;
		}

		public async Task UpdateCategoryAsync(UpdateCategoryDto model)
		{
			var category = await _repository.GetByIdAsync(model.CategoryId);
			category.CategoryName = model.CategoryName;
			await _repository.UpdateAsync(category);
		}
	}
}
