using LifeSafeAPI.Data.Models;

namespace LifeSafeAPI.Repository.Interfaces
{
    public interface IAuthorRepository
    {
        Task<List<AuthorGetDTO>> GetAll();
    }
}
