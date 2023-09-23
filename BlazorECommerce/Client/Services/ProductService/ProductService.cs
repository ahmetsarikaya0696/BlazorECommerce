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

        public event Action ProductsChanged;

        public async Task<ServiceResponse<Product>> GetProductByIdAsync(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<ServiceResponse<Product>>($"api/Products/{id}");
            return response;
        }

        public async Task GetProductsAsync(string categoryUrl)
        {
            string requestUrl = "api/Products";

            if (categoryUrl != null)
                requestUrl += $"/category/{categoryUrl}";

            var response = await _httpClient.GetFromJsonAsync<ServiceResponse<List<Product>>>(requestUrl);

            if (response?.Success == true)
                Products = response.Data;

            ProductsChanged.Invoke();
        }
    }
}
