namespace BlazorECommerce.Shared
{
    public class ServiceResponse<T> where T : class
    {
        public T? Data { get; set; }
        public bool Succes { get; set; } = true;
        public string Message { get; set; } = string.Empty;
    }
}
