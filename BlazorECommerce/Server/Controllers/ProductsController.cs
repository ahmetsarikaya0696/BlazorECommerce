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
            await Task.Delay(1000);
            return Ok(response);
        }
    }
}
