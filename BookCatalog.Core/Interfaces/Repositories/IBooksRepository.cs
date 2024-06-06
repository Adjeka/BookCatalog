using BookCatalog.Core.Models;

namespace BookCatalog.Core.Interfaces.Repositories
{
    public interface IBooksRepository
    {
        Task Create(Book book, List<int> CoauthorIds);
        Task Delete(int id);
        Task<List<Book>> Get();
        Task<Book> GetById(int id);
        Task Update(int id, string title, string description, int mainAuthorId, List<int> coauthorIds);
    }
}