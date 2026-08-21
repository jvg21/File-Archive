using FILEAPI.Data.Models;
using System.Linq.Expressions;

namespace FILEAPI.Repository.Interfaces
{
    public interface IBookRepository
    {
        Task<List<Book>> GetAll();
        Task<Book?> GetById(int id);
        Task<List<Book>> Get(Expression<Func<Book, bool>> predicate);

        Task<bool> Exists(Expression<Func<Book, bool>> predicate);

        Task<Book> Insert(Book book);
        Task Update(Book book);
        Task Delete(Book book);
    }
}
