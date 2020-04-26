namespace UseCases.Dto
{
    public class ProviderResult<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }

        public T Model { get; set; }
    }
}
