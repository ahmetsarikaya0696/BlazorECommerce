namespace BlazorECommerce.Client.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public List<Product> Products { get; set; }
        public string Message { get; set; } = "Loading Products...";

        public event Action ProductsChanged;

        public async Task<ServiceResponse<Product>> GetProductByIdAsync(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<ServiceResponse<Product>>($"api/Products/{id}");
            return response;
        }

        public async Task GetProductsAsync(string categoryUrl)
        {
            string requestUrl = "api/Products/featured";

            if (categoryUrl != null)
                requestUrl = $"/api/Products/category/{categoryUrl}";

            var response = await _httpClient.GetFromJsonAsync<ServiceResponse<List<Product>>>(requestUrl);

            if (response?.Success == true)
                Products = response.Data;

            ProductsChanged.Invoke();
        }

        public async Task<List<string>> GetProductSearchSuggestions(string searchText)
        {
            var result = await _httpClient.GetFromJsonAsync<ServiceResponse<List<string>>>($"api/Products/searchSuggestions/{searchText}");
            return result?.Data;
        }

        public async Task SearchProducts(string searchText)
        {
            var result = await _httpClient.GetFromJsonAsync<ServiceResponse<List<Product>>>($"api/Products/search/{searchText}");
            if (result?.Data != null)
                Products = result.Data;

            if (Products?.Count == 0)
                Message = "No product found.";

            ProductsChanged.Invoke();
        }
    }
}
