using FILEAPI.Data.Models;
using FILEAPI.Data.Request.Exceptions;
using FILEAPI.Repository;
using FILEAPI.Repository.Interfaces;
using FILEAPI.Services.Interfaces;
using Mapster;

namespace FILEAPI.Services
{
    public class BookAuthorService : IBookAuthorService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IAuthorRepository _authorRepository;
        private readonly IBookAuthorRepository _bookAuthorRepository;

        public BookAuthorService(IBookRepository bookRepository, IAuthorRepository authorRepository, IBookAuthorRepository bookAuthorRepository)
        {
            this._bookRepository = bookRepository;
            this._authorRepository = authorRepository;
            this._bookAuthorRepository = bookAuthorRepository;
        }

        public async Task<bool> Exists(BookAuthorDTO bookAuthorDTO)
        {
            BookAuthor bookAuthor = bookAuthorDTO.Adapt<BookAuthor>();
            return await _bookAuthorRepository.Exists(bookAuthor);
        }

        public async Task DeleteLinkBookToAuthor(BookAuthorDTO bookAuthorDTO)
        {
            BookAuthor bookAuthor = bookAuthorDTO.Adapt<BookAuthor>();

            bool linkExists = await _bookAuthorRepository.Exists(bookAuthor);

            if (!linkExists) throw new EntityNotFoundException("Book Link to Author Doesn't Exists");

            await  _bookAuthorRepository.DeleteLinkBookToAuthor(bookAuthor);

        }

        public async Task LinkBookToAuthor(BookAuthorDTO bookAuthorDTO)
        {
            bool bookExists = await _bookRepository.Exists((b)=>b.Id == bookAuthorDTO.IdBook);
            bool authorExists = await _authorRepository.Exists((a) => a.Id == bookAuthorDTO.IdAuthor);

            if(!bookExists || !authorExists) throw new EntityNotFoundException("Book or Author Doesn't Exists");

            BookAuthor bookAuthor = bookAuthorDTO.Adapt<BookAuthor>();
            await _bookAuthorRepository.LinkBookToAuthor(bookAuthor);
        }
    }
}
