

namespace BlazorECommerce.Server.Services.CartService
{
    public class CartService : ICartService
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public CartService(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<ServiceResponse<List<CartProductResponse>>> GetCartProducts(List<CartItem> cartItems)
        {
            var result = new ServiceResponse<List<CartProductResponse>>()
            {
                Data = new List<CartProductResponse>(),
            };

            foreach (var cartItem in cartItems)
            {
                var product = await _applicationDbContext.Products.FirstOrDefaultAsync(x => x.Id == cartItem.ProductId);

                if (product == null) continue;

                var productVariant = await _applicationDbContext.ProductVariants
                                                                 .Where(x => x.ProductId == cartItem.ProductId &&
                                                                             x.ProductTypeId == cartItem.ProductTypeId)
                                                                 .Include(x => x.ProductType)
                                                                 .FirstOrDefaultAsync();

                if (productVariant == null) continue;

                var cartProduct = new CartProductResponse
                {
                    ProductId = product.Id,
                    Title = product.Title,
                    ImageUrl = product.ImageUrl,
                    ProductType = productVariant.ProductType.Name,
                    ProductTypeId = productVariant.ProductTypeId,
                    Price = productVariant.Price,
                };

                result.Data.Add(cartProduct);
            }

            return result;
        }
    }
}
