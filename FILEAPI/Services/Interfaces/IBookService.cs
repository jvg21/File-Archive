using FILEAPI.Data.Models;
using System.Linq.Expressions;

namespace FILEAPI.Services.Interfaces
{
    public interface IBookService
    {
        Task<BookGetDTO?> GetById(int id);

        //Task<List<BookGetDTO>> GetByName(string name);
    }
}
