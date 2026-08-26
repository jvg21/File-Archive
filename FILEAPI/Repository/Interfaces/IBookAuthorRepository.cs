using FILEAPI.Data.Database;
using FILEAPI.Data.Models;

namespace FILEAPI.Repository.Interfaces
{
    public interface IBookAuthorRepository
    {

        Task LinkBookToAuthor(BookAuthor bookAuthor);
        Task DeleteLinkBookToAuthor(BookAuthor bookAuthor);
        Task<bool> Exists(BookAuthor bookAuthor);

    }
}
