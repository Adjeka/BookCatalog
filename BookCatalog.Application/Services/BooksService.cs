using BookCatalog.Core.Interfaces.Repositories;
using BookCatalog.Core.Interfaces.Services;
using BookCatalog.Core.Models;

namespace BookCatalog.Application.Services
{
    public class BooksService : IBooksService
    {
        private readonly IBooksRepository _booksRepository;

        public BooksService(IBooksRepository booksRepository)
        {
            _booksRepository = booksRepository;
        }

        public async Task<List<Book>> GetAllBooks()
        {
            return await _booksRepository.Get();
        }

        public async Task<Book> GetBookById(int id)
        {
            return await _booksRepository.GetById(id);
        }

        public async Task CreateBook(Book book, List<int> coauthorIds)
        {
            await _booksRepository.Create(book, coauthorIds);
        }

        public async Task UpdateBook(int id, string title, string description, int mainAuthorId, List<int> coauthorIds)
        {
            await _booksRepository.Update(id, title, description, mainAuthorId, coauthorIds);
        }

        public async Task DeleteBook(int id)
        {
            await _booksRepository.Delete(id);
        }
    }
}
