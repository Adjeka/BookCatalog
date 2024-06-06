using BookCatalog.Core.Models;

namespace BookCatalog.Core.Interfaces.Repositories
{
    public interface IAuthorsRepository
    {
        Task Create(Author author);
        Task Delete(int id);
        Task<List<Author>> Get();
        Task<Author> GetById(int id);
        Task Update(int id, string lastName, string firstName);
    }
}