using FILEAPI.Data.Models;
using FILEAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FILEAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            this._bookService = bookService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _bookService.GetAll();
            return Ok(response);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _bookService.GetById(id);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody]BookInsertDTO bookInsertDTO)
        {
            var response = await _bookService.Insert(bookInsertDTO);
            return CreatedAtAction(nameof(GetById), new { id = response.Id }, response);
        }

        [HttpPatch]
        public async Task<IActionResult> Update([FromBody] BookUpdateDTO bookUpdateDTO)
        {
            var response = await _bookService.Update(bookUpdateDTO);
            return Ok(response);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _bookService.Delete(id);
            return Ok();
        }
    }
}
