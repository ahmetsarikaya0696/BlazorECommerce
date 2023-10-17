﻿namespace BlazorECommerce.Server.Services.ProductService
{
	public interface IProductService
	{
		Task<ServiceResponse<List<Product>>> GetProductsAsync();
		Task<ServiceResponse<Product>> GetProductByIdAsync(int id);
		Task<ServiceResponse<List<Product>>> GetProductByCategory(string categoryUrl);
		Task<ServiceResponse<List<Product>>> SearchProducts(string searchText);
		Task<ServiceResponse<List<string>>> GetProductSearchSuggestions(string searchText);
        Task<ServiceResponse<List<Product>>> GetFeaturedProductsAsync();
    }
}
