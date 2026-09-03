using FILEAPI.Data.Models;
using System.Linq.Expressions;

namespace FILEAPI.Repository.Interfaces
{
    public interface IAuthorRepository
    {
        Task<List<Author>> GetAll();
        Task<Author?> GetById(int id);
        Task<List<Author>> Get(Expression<Func<Author, bool>> predicate);
        Task<bool> Exists(Expression<Func<Author, bool>> predicate);

        Task<Author> Insert(Author author);
        Task<Author> Update(Author author);
        Task Delete(Author author);


    }
}
