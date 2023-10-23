using BlazorECommerce.Shared;

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
                Data = await _applicationDbContext.Products
                                                  .Include(x => x.Variants)
                                                  .ToListAsync()
            };

            return response;
        }
        public async Task<ServiceResponse<Product>> GetProductByIdAsync(int id)
        {
            var product = await _applicationDbContext.Products
                                                     .Include(x => x.Variants)
                                                     .ThenInclude(x => x.ProductType)
                                                     .FirstOrDefaultAsync(x => x.Id == id);

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

        public async Task<ServiceResponse<List<Product>>> GetProductByCategory(string categoryUrl)
        {
            ServiceResponse<List<Product>> response = new()
            {
                Data = await _applicationDbContext.Products
                                                  .Include(x => x.Variants)
                                                  .Where(x => x.Category.Url.ToLower() == categoryUrl.ToLower())
                                                  .ToListAsync()
            };

            return response;
        }

        public async Task<ServiceResponse<ProductSearchResult>> SearchProducts(string searchText, int requestedPage)
        {
            var pageResult = 2f;
            var pageCount = Math.Ceiling((await GetProductsBySearchText(searchText)).Count / pageResult);
            var products = await _applicationDbContext.Products
                                                      .Where(x => x.Title.ToLower().Contains(searchText.ToLower())
                                                              || x.Description.ToLower().Contains(searchText.ToLower()))
                                                      .Include(x => x.Variants)
                                                      .Skip((requestedPage - 1) * (int)pageResult)
                                                      .Take((int)pageResult)
                                                      .ToListAsync();

            ServiceResponse<ProductSearchResult> response = new()
            {
                Data = new()
                {
                    Products = products,
                    Current = requestedPage,
                    Pages = (int)pageCount
                }
            };

            return response;
        }

        public async Task<ServiceResponse<List<string>>> GetProductSearchSuggestions(string searchText)
        {
            List<Product> productsBySearchText = await GetProductsBySearchText(searchText);
            List<string> result = new();

            foreach (var product in productsBySearchText)
            {
                if (product.Title.Contains(searchText, StringComparison.OrdinalIgnoreCase))
                {
                    result.Add(product.Title);
                }

                if (product.Description != null)
                {
                    var punctuations = product.Description.Where(char.IsPunctuation).Distinct().ToArray();

                    var words = product.Description.Split().Select(x => x.Trim(punctuations));

                    foreach (var word in words)
                    {
                        if (word.Contains(searchText, StringComparison.OrdinalIgnoreCase) && !result.Contains(word.ToLower()))
                        {
                            result.Add(word.ToLower());
                        }
                    }
                }
            }

            return new ServiceResponse<List<string>>()
            {
                Data = result
            };
        }

        private async Task<List<Product>> GetProductsBySearchText(string searchText)
        {
            return await _applicationDbContext.Products
                                              .Where(x => x.Title.ToLower().Contains(searchText.ToLower())
                                                      || x.Description.ToLower().Contains(searchText.ToLower()))
                                              .Include(x => x.Variants)
                                              .ToListAsync();
        }

        public async Task<ServiceResponse<List<Product>>> GetFeaturedProductsAsync()
        {
            ServiceResponse<List<Product>> response = new()
            {
                Data = await _applicationDbContext.Products
                                                  .Where(x => x.Featured)
                                                  .Include(x => x.Variants)
                                                  .ToListAsync(),
            };

            return response;
        }
    }
}
