

using LifeSafeAPI.Data.Models;
using LifeSafeAPI.Repository.Interfaces;
using LifeSafeAPI.Services.Interfaces;

namespace LifeSafeAPI.Services
{
    public class AuthorService:IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorService(IAuthorRepository authorRepository)
        {
            this._authorRepository = authorRepository;
        }

        public async Task<List<AuthorGetDTO>> GetAll()
        {
            try
            {
                var request = await _authorRepository.GetAll();

                return request;
            }
            catch (Exception ex) { 
                   throw new Exception(ex.Message, ex);
            }
        }
    }
}
