

using FILEAPI.Data.Models;
using FILEAPI.Data.Request.Exceptions;
using FILEAPI.Repository;
using FILEAPI.Repository.Interfaces;
using FILEAPI.Services.Interfaces;
using Mapster;
using System.Net;

namespace FILEAPI.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorService(IAuthorRepository authorRepository, IBookService bookService)
        {
            this._authorRepository = authorRepository;
        }

        public async Task<List<AuthorGetDTO>> GetAll()
        {
            var request = await _authorRepository.GetAll();
            return request.Adapt<List<AuthorGetDTO>>();
        }

        public async Task<AuthorGetDTO> GetById(int id)
        {
            var request = await _authorRepository.GetById(id);
            if (request == null) throw new EntityNotFoundException();

            return request.Adapt<AuthorGetDTO>(); ;
        }

        public async Task<AuthorGetDTO> Insert(AuthorInsertDTO authorDto)
        {
            if (authorDto == null) throw new InvalidFormException();

            var author = authorDto.Adapt<Author>();
            var request = await _authorRepository.Insert(author);
            var response = request.Adapt<AuthorGetDTO>();

            return response;

        }

        public async Task<AuthorGetDTO> Update(AuthorUpdateDTO authorDto)
        {
            if (authorDto == null) throw new InvalidFormException();

            Author? author = await _authorRepository.GetById(authorDto.Id);

            if (author == null) throw new EntityNotFoundException();

            //Update values
            if (authorDto.Name != null) author.Name = authorDto.Name;

            var request = await _authorRepository.Update(author);
            return request.Adapt<AuthorGetDTO>();

        }

        public async Task Delete(int id)
        {
            Author? author = await _authorRepository.GetById(id);
            if (author == null) throw new EntityNotFoundException();
            await _authorRepository.Delete(author);
        }

    }
}
