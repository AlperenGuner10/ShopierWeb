using Shopier.Application.Dtos.OrderItemDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopier.Application.Usecases.OrderItemItemServices
{
	public interface IOrderItemItemService
	{
		Task<List<ResultOrderItemDto>> GetAllOrderItemAsync();
		Task<GetByIdOrderItemDto> GetByIdOrderItemAsync(int id);
		Task CreateOrderItemAsync(CreateOrderItemDto model);
		Task UpdateOrderItemAsync(UpdateOrderItemDto model);
		Task DeleteOrderItemAsync(int id);
	}
}
