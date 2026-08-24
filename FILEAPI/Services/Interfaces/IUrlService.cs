using FILEAPI.Data.Models;
using System.Linq.Expressions;

namespace FILEAPI.Services.Interfaces
{
    public interface IUrlService
    {
        Task<List<UrlGetDTO>> GetAll();
        Task<UrlGetDTO?> GetById(int id);
        //Task<bool> Exists(int id);
        Task<UrlGetDTO> Insert(UrlInsertDTO book);
        Task<UrlGetDTO> Update(UrlUpdateDTO book);
        Task Delete(int id);
    }
}
