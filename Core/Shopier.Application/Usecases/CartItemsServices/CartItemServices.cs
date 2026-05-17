using Shopier.Application.Dtos.CartItemDtos;
using Shopier.Application.Interfaces;
using Shopier.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopier.Application.Usecases.CartItemsServices
{
	public class CartItemServices : ICartItemServices
	{
		private readonly IRepository<CartItem> _cartItemRepository;

		public CartItemServices(IRepository<CartItem> cartItemRepository)
		{
			_cartItemRepository=cartItemRepository;
		}

		public async Task CreateCartItemAsync(CreateCartItemDto model)
		{
			var cartItem = new CartItem
			{
				//CartId = model.CartId,
				ProductId = model.ProductId,
				Quantity = model.Quantity,
				TotalPrice = model.TotalPrice,
			};
			await _cartItemRepository.CreateAsync(cartItem);
		}

		public async Task DeleteCartItemAsync(int id)
		{
			var cartItem = await _cartItemRepository.GetByIdAsync(id);
			await _cartItemRepository.DeleteAsync(cartItem);
		}

		public async Task<List<ResultCartItemDto>> GetAllCartItemAsync()
		{
			var cartItems = await _cartItemRepository.GetAllAsync();
			return cartItems.Select(x => new ResultCartItemDto
			{
				CartId = x.CartId,
				ProductId = x.ProductId,
				CartItemId = x.CartItemId,
				Quantity = x.Quantity,
				TotalPrice = x.TotalPrice,
			}).ToList();
		}

		public async Task<GetByIdCartItemDto> GetByIdCartItemAsync(int id)
		{
			var cartItem = await _cartItemRepository.GetByIdAsync(id);
			return new GetByIdCartItemDto
			{
				Quantity = cartItem.Quantity,
				CartItemId = cartItem.CartItemId,
				ProductId = cartItem.ProductId,
				CartId = cartItem.CartItemId,
				TotalPrice= cartItem.TotalPrice,
			};
		}

		public async Task UpdateCartItemAsync(UpdateCartItemDto model)
		{
			var cartItem = await _cartItemRepository.GetByIdAsync(model.CartId);	
			cartItem.Quantity = model.Quantity;
			cartItem.ProductId = model.ProductId;
			cartItem.TotalPrice = model.TotalPrice;
			cartItem.CartId = model.CartId;
			await _cartItemRepository.UpdateAsync(cartItem);
		}
	}
}
