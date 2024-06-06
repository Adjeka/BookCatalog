using BookCatalog.Core.Models;

namespace BookCatalog.Core.Interfaces.Services
{
    public interface IBooksService
    {
        Task CreateBook(Book book, List<int> CoauthorIds);
        Task DeleteBook(int id);
        Task<List<Book>> GetAllBooks();
        Task<Book> GetBookById(int id);
        Task UpdateBook(int id, string title, string description, int mainAuthorId, List<int> coauthorIds);
    }
}