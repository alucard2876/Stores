
namespace DomainAccess
{
    public class Result
    {
        public string Message { get; set; }
        public bool IsCompleted { get; set; }
    }
    public class Result<T> : Result
    {
        public T Data { get; set; }
    }
}
