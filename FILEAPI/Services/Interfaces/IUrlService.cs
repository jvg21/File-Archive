using FILEAPI.Data.Models;
using System.Linq.Expressions;

namespace FILEAPI.Services.Interfaces
{
    public interface IUrlService
    {
        Task<List<UrlGetDTO>> GetAll();
        Task<UrlGetDTO?> GetById(int id);
        //Task<bool> Exists(int id);
        Task<UrlGetDTO> Insert(UrlInsertDTO url);
        Task<UrlGetDTO> Update(UrlUpdateDTO url);
        Task Delete(int id);
    }
}
