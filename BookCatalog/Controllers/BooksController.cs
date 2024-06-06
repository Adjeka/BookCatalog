using BookCatalog.Contracts.Authors;
using BookCatalog.Contracts.Books;
using BookCatalog.Core.Interfaces.Services;
using BookCatalog.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookCatalog.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBooksService _booksService;

        public BooksController(IBooksService booksService)
        {
            _booksService = booksService;
        }

        [HttpGet]
        public async Task<ActionResult<List<BooksResponse>>> GetBooks()
        {
            var books = await _booksService.GetAllBooks();
            var response = books.Select(b => new BooksResponse(b.Id,b.Title,b.Description,b.MainAuthorId,
                b.Coauthors.Select(ca => new AuthorsResponse(ca.Id, ca.FirstName, ca.LastName)).ToList())).ToList();

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BooksResponse>> GetBookById(int id)
        {
            var book = await _booksService.GetBookById(id);

            var response = new BooksResponse(book.Id, book.Title, book.Description, book.MainAuthorId,
                book.Coauthors.Select(ca => new AuthorsResponse(ca.Id, ca.FirstName, ca.LastName)).ToList());

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult> CreateBook([FromBody] BooksRequest request)
        {
            var book = Book.Create(0, request.Title, request.Description, request.MainAuthorId, new List<Author>());

            await _booksService.CreateBook(book, request.CoauthorIds);

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateBook(int id, [FromBody] BooksRequest request)
        {
            var book = await _booksService.GetBookById(id);
            if (book == null) throw new ArgumentNullException();

            await _booksService.UpdateBook(id, request.Title, request.Description, request.MainAuthorId, request.CoauthorIds);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBook(int id)
        {
            await _booksService.DeleteBook(id);

            return Ok();
        }
    }
}
