namespace BlazorECommerce.Server.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public ProductService(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<ServiceResponse<List<Product>>> GetProductsAsync()
        {
            var response = new ServiceResponse<List<Product>>()
            {
                Data = await _applicationDbContext.Products.ToListAsync()
            };

            return response;
        }
        public async Task<ServiceResponse<Product>> GetProductByIdAsync(int id)
        {
            var product = await _applicationDbContext.Products.FindAsync(id);

            var response = new ServiceResponse<Product>();

            if (product == null)
            {
                response.Message = "Not Found!";
                response.Success = false;

                return response;
            }

            response.Data = product;

            return response;
        }
    }
}
