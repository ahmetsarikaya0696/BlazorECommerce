namespace BlazorECommerce.Client.Services.ProductService
{
    public interface IProductService
    {
        Task<List<Product>> GetProductsAsync();
        Task<ServiceResponse<Product>> GetProductByIdAsync(int id);
    }
}
