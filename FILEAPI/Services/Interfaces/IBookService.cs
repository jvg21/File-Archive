using FILEAPI.Data.Models;
using System.Linq.Expressions;

namespace FILEAPI.Services.Interfaces
{
    public interface IBookService
    {
        Task<List<BookGetDTO>> GetAll();
        Task<BookGetDTO> GetById(int id);
        Task<BookGetDTO> Insert(BookInsertDTO book);
        Task<BookGetDTO> Update(BookUpdateDTO book);
        Task Delete(int id);
    }
}
