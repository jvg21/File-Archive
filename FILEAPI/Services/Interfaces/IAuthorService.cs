using FILEAPI.Data.DTOs.Author;
using FILEAPI.Data.Models;

namespace FILEAPI.Services.Interfaces
{
    public interface IAuthorService
    {
        Task<List<AuthorGetDTO>> GetAll();
        Task<AuthorGetDTO?> GetById(int id);
        Task<bool> Exists(int id);
        Task<Author> Insert(Author author);
        Task Update();
        Task Delete(Author author);
    }
}
