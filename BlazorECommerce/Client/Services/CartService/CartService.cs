﻿
using Blazored.LocalStorage;

namespace BlazorECommerce.Client.Services.CartService
{
    public class CartService : ICartService
    {
        private readonly ILocalStorageService _localStorageService;

        public CartService(ILocalStorageService localStorageService)
        {
            _localStorageService = localStorageService;
        }

        public event Action OnChange;

        public async Task AddToCart(CartItem cartItem)
        {
            var cart = await GetCartAsync();

            cart.Add(cartItem);

            await _localStorageService.SetItemAsync("cart", cart);
        }

        public async Task<List<CartItem>> GetCartItems() => await GetCartAsync();

        private async Task<List<CartItem>> GetCartAsync()
        {
            var cart = await _localStorageService.GetItemAsync<List<CartItem>>("cart");

            if (cart == null)
            {
                cart = new();
            }

            return cart;
        }
    }
}