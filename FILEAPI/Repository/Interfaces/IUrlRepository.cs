using FILEAPI.Data.Models;
using System.Linq.Expressions;

namespace FILEAPI.Repository.Interfaces
{
    public interface IUrlRepository
    {
        Task<List<Url>> GetAll();
        Task<Url?> GetById(int id);
        Task<List<Url>> Get(Expression<Func<Url, bool>> predicate);
        
        //Task<bool> Exists(Expression<Func<Url, bool>> predicate);

        Task<Url> Insert(Url url);
        Task<Url> Update(Url url);
        Task Delete(Url url);


    }
}
