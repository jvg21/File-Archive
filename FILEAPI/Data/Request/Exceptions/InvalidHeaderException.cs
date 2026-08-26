
using System.Net;

namespace FILEAPI.Data.Request.Exceptions
{
    public class InvalidHeaderException : HttpException
    {
        public InvalidHeaderException(string message = "Input Headers Have Invalid Data") : base(message, HttpStatusCode.BadRequest)
        {}
    }
}
