using Shopier.Application.Dtos.CartItemDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopier.Application.Usecases.CartItemsServices
{
	public interface ICartItemServices
	{
		Task<List<ResultCartItemDto>> GetAllCartItemAsync();
		Task<GetByIdCartItemDto> GetByIdCartItemAsync(int id);
		Task CreateCartItemAsync(CreateCartItemDto model);
		Task UpdateCartItemAsync(UpdateCartItemDto model);
		Task DeleteCartItemAsync(int id);
	}
}
