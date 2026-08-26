using FILEAPI.Data.Models;

namespace FILEAPI.Services.Interfaces
{
    public interface IBookAuthorService
    {
        Task LinkBookToAuthor(BookAuthorDTO bookAuthorDTO);
        Task DeleteLinkBookToAuthor(BookAuthorDTO bookAuthorDTO);
    }
}
