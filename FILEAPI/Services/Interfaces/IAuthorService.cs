using LifeSafeAPI.Data.Models;

namespace LifeSafeAPI.Services.Interfaces
{
    public interface IAuthorService
    {
        Task<List<AuthorGetDTO>> GetAll();
    }
}
