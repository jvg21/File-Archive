using FILEAPI.Data.Models;

namespace FILEAPI.Services.Interfaces
{
    public interface IAuthorService
    {
        Task<List<AuthorGetDTO>> GetAll();
        Task<AuthorGetDTO> GetById(int id);
        Task<AuthorGetDTO> Insert(AuthorInsertDTO author);
        Task<AuthorGetDTO> Update(AuthorUpdateDTO author);
        Task Delete(int id);
    }
}
