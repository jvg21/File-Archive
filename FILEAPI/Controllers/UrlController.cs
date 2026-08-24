using FILEAPI.Data.Models;
using FILEAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FILEAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UrlController : ControllerBase
    {
        private readonly IUrlService _urlService;

        public UrlController(IUrlService urlService)
        {
            this._urlService = urlService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _urlService.GetAll();
            return Ok(response);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _urlService.GetById(id);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody]UrlInsertDTO urlInsertDTO)
        {
            var response = await _urlService.Insert(urlInsertDTO);
            return CreatedAtAction(nameof(GetById), new { id = response.Id }, response);
        }

        [HttpPatch]
        public async Task<IActionResult> Update([FromBody] UrlUpdateDTO urlUpdateDTO)
        {
            var response = await _urlService.Update(urlUpdateDTO);
            return Ok(response);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _urlService.Delete(id);
            return Ok();
        }
    }
}
