using FILEAPI.Data.Models;
using FILEAPI.Data.Request.Exceptions;
using FILEAPI.Repository;
using FILEAPI.Repository.Interfaces;
using FILEAPI.Services.Interfaces;
using FILEAPI.Utils;
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

        public async Task<List<BookGetDTO>> GetAll()
        {
            var request= await _bookRepository.GetAll();
            return request.Adapt<List<BookGetDTO>>();
        }

        public async Task<BookGetDTO> GetById(int id)
        {
            var request = await _bookRepository.GetById(id);
            if (request == null) throw new EntityNotFoundException();

            var response = request.Adapt<BookGetDTO>();
            return response;
        }

        public async Task<BookGetDTO> Insert(BookInsertDTO bookDto)
        {
            if(bookDto == null) throw new InvalidFormException();
            Book book = bookDto.Adapt<Book>();
            var request = await _bookRepository.Insert(book);
            return request.Adapt<BookGetDTO>();
        }

        public async Task<BookGetDTO> Update(BookUpdateDTO bookDto)
        {
            /*Verify Values*/
            if (bookDto == null) throw new InvalidFormException();
            if (bookDto.Rating != null && (bookDto.Rating > 10 || bookDto.Rating < 0)) throw new InvalidFormException("Rating Value Invalid, must be between 0 and 10");
            if (bookDto.CurrentChapter != null && bookDto.TotalChapters!=null && (bookDto.CurrentChapter>bookDto.TotalChapters) ) throw new InvalidFormException("Current Chapter Value Higher Than Total Chapters");

            Book? book = await _bookRepository.GetById(bookDto.Id);
            if (book == null) throw new EntityNotFoundException();

            /****update values*/
            if(bookDto.Name !=null) book.Name = bookDto.Name;
            if(bookDto.Notes !=null) book.Notes = bookDto.Notes;

            if (bookDto.Summary !=null) book.Summary = bookDto.Summary;

            /*int*/
            if (bookDto.Words != null) book.Words = bookDto.Words.Value;
            if (bookDto.Rating != null) book.Rating = bookDto.Rating.Value;
            if (bookDto.ReadingStatus != null && Enum.IsDefined(typeof(ModelEnums.ReadingStatus),bookDto.ReadingStatus.Value)) book.ReadingStatus = bookDto.ReadingStatus.Value;
            if (bookDto.WritingStatus != null && Enum.IsDefined(typeof(ModelEnums.WritingStatus), bookDto.WritingStatus.Value)) book.WritingStatus = bookDto.WritingStatus.Value;
            if (bookDto.CurrentChapter != null) book.CurrentChapter = bookDto.CurrentChapter.Value;

            var request = await _bookRepository.Update(book);
            return request.Adapt<BookGetDTO>();

        }

        public async Task Delete(int id)
        {
            Book? book = await _bookRepository.GetById(id);
            if (book == null) throw new EntityNotFoundException();

            await _bookRepository.Delete(book);
        }
    }
}
