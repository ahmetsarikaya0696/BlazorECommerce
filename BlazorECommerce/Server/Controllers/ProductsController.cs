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
            // İlk çalıştırmada 3 saniye bekliyor ama sonrakilerde cache ' ten alıyor.
            var response = await _productService.GetProductsAsync();
            await Task.Delay(3000);
            return Ok(response);
        }
    }
}
