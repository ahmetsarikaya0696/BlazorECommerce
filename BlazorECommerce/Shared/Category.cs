namespace BlazorECommerce.Shared
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }

        public List<Product> Products { get; set; }
    }
}
