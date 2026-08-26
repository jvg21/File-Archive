using FILEAPI.Data.Models;
using FILEAPI.Data.Request.Exceptions;
using FILEAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FILEAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookAuthorController : ControllerBase
    {
        private readonly IBookAuthorService _bookAuthorService;

        public BookAuthorController(IBookAuthorService bookAuthorService)
        {
            this._bookAuthorService = bookAuthorService;
        }


        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] BookAuthorDTO bookAuthorDTO)
        {

            await _bookAuthorService.LinkBookToAuthor(bookAuthorDTO);
            return Created();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] BookAuthorDTO bookAuthorDTO)
        {
            await _bookAuthorService.DeleteLinkBookToAuthor(bookAuthorDTO);
            return Ok();
        }
    }
}
