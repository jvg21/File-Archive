using FILEAPI.Data.DTOs.Author;
using FILEAPI.Data.Models;

namespace FILEAPI.Repository.Interfaces
{
    public interface IAuthorRepository
    {
        Task<List<Author>> GetAll();
        Task<Author?> GetById(int id);
        Task<bool> Exists(int id);
        Task<Author> Insert(Author author);
        Task Update();
        Task Delete(Author author);


    }
}
