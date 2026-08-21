using FILEAPI.Data.Models;
using FILEAPI.Data.Request.Exceptions;
using FILEAPI.Repository;
using FILEAPI.Repository.Interfaces;
using FILEAPI.Services.Interfaces;
using Mapster;
using System.Linq.Expressions;

namespace FILEAPI.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }


        public async Task<BookGetDTO?> GetById(int id)
        {
            var request = await _bookRepository.GetById(id);
            var response = request.Adapt<BookGetDTO>();
            return response;
        }

        public async Task<List<Book>> GetByName(string name)
        {
            var request = await _bookRepository.Get((b => b.Name.ToLower().Contains(name.ToLower())));
            return request;
        }


        public async Task Delete(int id)
        {
            Book? book = await _bookRepository.GetById(id);
            if (book == null) throw new EntityNotFoundException();
            await _bookRepository.Delete(book);
        }
    }
}
