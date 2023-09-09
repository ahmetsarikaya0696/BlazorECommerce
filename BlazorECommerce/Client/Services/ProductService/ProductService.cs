namespace BlazorECommerce.Client.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ServiceResponse<Product>> GetProductByIdAsync(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<ServiceResponse<Product>>($"api/Products/{id}");
            return response;
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<ServiceResponse<List<Product>>>("api/Products");

            if (response?.Success == true)
                return response.Data;

            return null;
        }
    }
}
