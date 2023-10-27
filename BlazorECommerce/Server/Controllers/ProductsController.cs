using Microsoft.AspNetCore.Mvc;

namespace BlazorECommerce.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Product>>>> GetProducts()
        {
            // İlk çalıştırmada 1 saniye bekliyor ama sonrakilerde cache ' ten alıyor.
            var response = await _productService.GetProductsAsync();
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<Product>>> GetProductById(int id)
        {
            var response = await _productService.GetProductByIdAsync(id);
            return Ok(response);
        }

        [HttpGet("category/{categoryUrl}")]
        public async Task<ActionResult<ServiceResponse<List<Product>>>> GetProductsByCategory(string categoryUrl)
        {
            var response = await _productService.GetProductByCategory(categoryUrl);
            return Ok(response);
        }

        [HttpGet("search/{searchText}/page/{requestedPage}")]
        public async Task<ActionResult<ServiceResponse<ProductSearchResult>>> GetProductsBySearchText(string searchText, int requestedPage)
        {
            var response = await _productService.SearchProducts(searchText, requestedPage);
            return Ok(response);
        }

        [HttpGet("searchSuggestions/{searchText}")]
        public async Task<ActionResult<ServiceResponse<List<Product>>>> GetProductSuggestionsBySearchText(string searchText)
        {
            var response = await _productService.GetProductSearchSuggestions(searchText);
            return Ok(response);
        }

        [HttpGet("featured")]
        public async Task<ActionResult<ServiceResponse<List<Product>>>> GetFeaturedProducts()
        {
            var response = await _productService.GetFeaturedProductsAsync();
            return Ok(response);
        }
    }
}
