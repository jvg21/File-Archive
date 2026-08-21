
using System.Net;

namespace FILEAPI.Data.Request.Exceptions
{
    public class InvalidFormException : HttpException
    {
        public InvalidFormException(string message = "Input Form Have Invalid Data") : base(message, HttpStatusCode.BadRequest)
        {}
    }
}
