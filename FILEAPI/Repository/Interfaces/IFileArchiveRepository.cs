using FILEAPI.Data.Maps;
using FILEAPI.Data.Models;
using System.Linq.Expressions;

namespace FILEAPI.Repository.Interfaces
{
    public interface IFileArchiveRepository
    {
        Task<List<FileArchive>> GetAll();
        Task<FileArchive?> GetById(int id);
        Task<List<FileArchive>> Get(Expression<Func<FileArchive, bool>> predicate);


        Task<FileArchive> Insert(FileArchive book);
        Task<FileArchive> Update(FileArchive book);
        Task Delete(FileArchive book);
    }
}
