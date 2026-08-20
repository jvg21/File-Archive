namespace FILEAPI.Data.Request
{
    public class RequestReturn<T>
    {
        public T? Data { get; set; }
        public int Status { get; set; } = 500;
        public string Message { get; set; } = string.Empty;

       
    }
}
