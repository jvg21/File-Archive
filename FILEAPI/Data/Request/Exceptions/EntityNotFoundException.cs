
using System.Net;

namespace FILEAPI.Data.Request.Exceptions
{
    public class EntityNotFoundException : HttpException
    {
        public EntityNotFoundException(string message = "Intended Entity Not Found") : base(message, HttpStatusCode.NotFound)
        {}
    }
}
