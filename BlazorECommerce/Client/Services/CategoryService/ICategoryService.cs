namespace BlazorECommerce.Client.Services.CategoryService
{
    public interface ICategoryService
    {
        Task<List<Category>> GetCategoriesAsync();
    }
}
