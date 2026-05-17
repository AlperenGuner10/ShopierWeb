using Shopier.Application.Dtos.ProductDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopier.Application.Usecases.ProductServices
{
	public interface IProductServices
	{
		Task<List<ResultProductDto>> GetAllProductAsync();
		Task<GetByIdProductDto> GetByIdProductAsync(int id);
		Task CreateProductAsync(CreateProductDto model);
		Task UpdateProductAsync(UpdateProductDto model);
		Task DeleteProductAsync(int id);
	}
}
