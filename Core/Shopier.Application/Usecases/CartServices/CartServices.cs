using Shopier.Application.Dtos.CartDtos;
using Shopier.Application.Dtos.CartItemDtos;
using Shopier.Application.Interfaces;
using Shopier.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopier.Application.Usecases.CartServices
{
	public class CartServices : ICartServices
	{
		private readonly IRepository<Cart> _cartRepository;
		private readonly IRepository<CartItem> _cartItemRepository;

		public CartServices(IRepository<Cart> cartRepository, IRepository<CartItem> cartItemRepository)
		{
			_cartRepository=cartRepository;
			_cartItemRepository=cartItemRepository;
		}

		public async Task CreateCartAsync(CreateCartDto model)
		{
			var cart = new Cart
			{
				//TotalAmount = model.TotalAmount,
				CreatedDate = DateTime.Now,
				CustomerId = model.CustomerId,
			};
			await _cartRepository.CreateAsync(cart);
			var sum = 0;

			foreach (var item in model.CartItems)
			{
				var cartItem = new CartItem
				{
					CartId = cart.CartId,
					ProductId = item.ProductId,
					Quantity = item.Quantity,
					TotalPrice = item.TotalPrice,
				};
				sum = sum + (item.Quantity*item.TotalPrice);
				await _cartItemRepository.CreateAsync(cartItem);
			}
			cart.TotalAmount = sum;
			await _cartRepository.UpdateAsync(cart);
		}

		public async Task DeleteCartAsync(int id)
		{
			var cart = await _cartRepository.GetByIdAsync(id);
			await _cartRepository.DeleteAsync(cart);
		}

		public async Task<List<ResultCartDto>> GetAllCartAsync()
		{
			var carts = await _cartRepository.GetAllAsync();
			var cartItem = await _cartItemRepository.GetAllAsync();
			return carts.Select(x => new ResultCartDto
			{
				CartId = x.CartId,
				CreatedDate= x.CreatedDate,
				CustomerId = x.CustomerId,
				TotalAmount = x.TotalAmount,
				CartItems = x.CartItems.Select(y => new ResultCartItemDto
				{
					CartId = y.CartId,
					CartItemId = y.CartItemId,
					ProductId = y.ProductId,
					Quantity = y.Quantity,
					TotalPrice = y.TotalPrice,
				}).ToList()
			}).ToList();
		}

		public async Task<GetByIdCartDto> GetByIdCartAsync(int id)
		{
			var cart = await _cartRepository.GetByIdAsync(id);
			var result = new GetByIdCartDto
			{
				CartId = cart.CartId,
				//CartItems = cart.CartItems,
				CreatedDate = cart.CreatedDate,
				CustomerId = cart.CustomerId
			};
			return result;
		}

		public async Task UpdateCartAsync(UpdateCartDto model)
		{
			var cart = await _cartRepository.GetByIdAsync(model.CartId);
			cart.CreatedDate = model.CreatedDate;
			cart.CustomerId = model.CustomerId;
			cart.TotalAmount = model.TotalAmount;
			await _cartRepository.UpdateAsync(cart);
		}
	}
}
