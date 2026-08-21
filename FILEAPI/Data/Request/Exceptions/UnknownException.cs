
using System.Net;

namespace FILEAPI.Data.Request.Exceptions
{
    public class UnknownException : HttpException
    {
        public UnknownException(string message = "Unknown Exception") : base(message, HttpStatusCode.InternalServerError)
        {}
    }
}
