using BookCatalog.Contracts.Authors;
using BookCatalog.Core.Interfaces.Services;
using BookCatalog.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookCatalog.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorsService _authorsService;

        public AuthorsController(IAuthorsService authorsService)
        {
            _authorsService = authorsService;
        }

        [HttpGet]
        public async Task<ActionResult<List<AuthorsResponse>>> GetAuthors()
        {
            var authors = await _authorsService.GetAllAuthors();

            var response = authors.Select(b => new AuthorsResponse(b.Id, b.LastName, b.FirstName));

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorsResponse>> GetAuthorById(int id)
        {
            var author = await _authorsService.GetAuthorById(id);

            var response = new AuthorsResponse(author.Id, author.LastName, author.FirstName);

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult> CreateAuthor([FromBody] AuthorsRequest request)
        {
            var author = Author.Create(0, request.LastName, request.FirstName);

            await _authorsService.CreateAuthor(author);

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAuthor(int id, [FromBody] AuthorsRequest request)
        {
            await _authorsService.UpdateAuthor(id, request.LastName, request.FirstName);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAuthor(int id)
        {
            await _authorsService.DeleteAuthor(id);

            return Ok();
        }
    }
}
