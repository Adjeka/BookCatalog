using BookCatalog.Core.Models;

namespace BookCatalog.Core.Interfaces.Services
{
    public interface IAuthorsService
    {
        Task CreateAuthor(Author author);
        Task DeleteAuthor(int id);
        Task<List<Author>> GetAllAuthors();
        Task<Author> GetAuthorById(int id);
        Task UpdateAuthor(int id, string lastName, string firstName);
    }
}