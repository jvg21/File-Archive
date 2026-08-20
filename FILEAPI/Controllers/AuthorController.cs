
using FILEAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FILEAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthorController : ControllerBase
    {
         private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var request = await _authorService.GetAll();
                return Ok(request);
            }
            catch (Exception ex) { 
                
                return BadRequest(ex.Message);
            
            }
        }
    }
}
