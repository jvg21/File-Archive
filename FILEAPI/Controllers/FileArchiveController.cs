using FILEAPI.Data.Models;
using FILEAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FILEAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FileArchiveController : ControllerBase
    {
        private readonly IFileArchiveService _fileArchiveService;

        public FileArchiveController(IFileArchiveService fileArchiveService)
        {
            this._fileArchiveService = fileArchiveService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _fileArchiveService.GetAll();
            return Ok(response);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _fileArchiveService.GetById(id);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] FileArchiveInsertDTO fileArchiveInsertDTO)
        {
            var response = await _fileArchiveService.Insert(fileArchiveInsertDTO);
            return CreatedAtAction(nameof(GetById), new { id = response.Id }, response);
        }

        [HttpPatch]
        public async Task<IActionResult> Update([FromBody] FileArchiveUpdateDTO fileArchiveUpdateDTO)
        {
            var response = await _fileArchiveService.Update(fileArchiveUpdateDTO);
            return Ok(response);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _fileArchiveService.Delete(id);
            return Ok();
        }
    }
}
