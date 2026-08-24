using FILEAPI.Data.Database;

namespace FILEAPI.Repository.Interfaces
{
    public interface IBookAuthorRepository
    {

        Task LinkBookToAuthor(int idBook, int idAuthor);
        Task DeleteLinkBookToAuthor(int idBook, int idAuthor);
        Task<bool> Exists(int idBook, int idAuthor);

    }
}
