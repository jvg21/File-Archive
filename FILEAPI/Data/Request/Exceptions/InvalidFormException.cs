
using System.Net;

namespace FILEAPI.Data.Request.Exceptions
{
    public class InvalidFormException : HttpException
    {
        public InvalidFormException(string message) : base(message, HttpStatusCode.BadRequest)
        {}
    }
}
