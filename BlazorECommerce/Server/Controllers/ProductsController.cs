using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorECommerce.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public ProductsController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            // İlk çalıştırmada 3 saniye bekliyor ama sonrakilerde cache ' ten alıyor.
            var products = await _dbContext.Products.ToListAsync();
            await Task.Delay(3000);
            return Ok(products);
        }
    }
}
