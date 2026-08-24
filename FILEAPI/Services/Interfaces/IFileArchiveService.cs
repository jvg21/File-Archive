using FILEAPI.Data.Models;
using System.Linq.Expressions;

namespace FILEAPI.Services.Interfaces
{
    public interface IFileArchiveService
    {
        Task<List<FileArchiveGetDTO>> GetAll();
        Task<FileArchiveGetDTO?> GetById(int id);
        //Task<bool> Exists(int id);
        Task<FileArchiveGetDTO> Insert(FileArchiveInsertDTO fileArchiveInsertDTO);
        Task<FileArchiveGetDTO> Update(FileArchiveUpdateDTO fileArchiveUpdateDTO);
        Task Delete(int id);
    }
}
