using System.Net;

namespace FILEAPI.Data.Request.Exceptions
{
    public class HttpException : Exception
    {   
        public HttpStatusCode StatusCode { get; }
        protected HttpException(string message,HttpStatusCode statusCode) : base(message)
        {
            StatusCode = statusCode;
        }
    }
}
