

using FILEAPI.Data.DTOs.Author;
using FILEAPI.Repository.Interfaces;
using FILEAPI.Services.Interfaces;
using Mapster;

namespace FILEAPI.Services
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

                var response = request.Adapt<List<AuthorGetDTO>>();

                return response;
            }
            catch (Exception ex) { 
                   throw new Exception(ex.Message, ex);
            }
        }
    }
}
