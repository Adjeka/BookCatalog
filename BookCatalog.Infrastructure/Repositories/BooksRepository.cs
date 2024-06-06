using AutoMapper;
using BookCatalog.Core.Interfaces.Repositories;
using BookCatalog.Core.Models;
using BookCatalog.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BookCatalog.Infrastructure.Repositories
{
    public class BooksRepository : IBooksRepository
    {
        private readonly BookCatalogDbContext _context;
        private readonly IMapper _mapper;

        public BooksRepository(BookCatalogDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<Book>> Get()
        {
            var bookEntities = await _context.Books
                .Include(b => b.MainAuthor)
                .Include(b => b.BookAuthors)
                .ThenInclude(ba => ba.Author)
                .AsNoTracking()
                .ToListAsync();

            var books = bookEntities.Select(be => Book.Create(be.Id, be.Title, be.Description, be.MainAuthorId, 
                _mapper.Map<List<Author>>(be.BookAuthors.Select(ba => ba.Author)))).ToList();

            return books;
        }

        public async Task<Book> GetById(int id)
        {
            var bookEntity = await _context.Books
                .Include(b => b.MainAuthor)
                .Include(b => b.BookAuthors)
                .ThenInclude(ba => ba.Author)
                .AsNoTracking()
                .FirstOrDefaultAsync(b => b.Id == id) ?? throw new Exception($"Книга с таким id:{id} не найдена");

            var coauthors = _mapper.Map<List<Author>>(bookEntity.BookAuthors.Select(ba => ba.Author));

            var book = Book.Create(bookEntity.Id, bookEntity.Title, bookEntity.Description, bookEntity.MainAuthorId, coauthors);

            return book;
        }

        public async Task Create(Book book, List<int> coauthorIds)
        {
            if (coauthorIds.Contains(book.MainAuthorId))
                throw new Exception("Главный автор не может быть еще и соавтором");

            var bookEntity = new BookEntity()
            {
                Title = book.Title,
                Description = book.Description,
                MainAuthorId = book.MainAuthorId,
                BookAuthors = coauthorIds.Select(id => new BookAuthorEntity { AuthorId = id }).ToList()
            };

            _context.Books.Add(bookEntity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(int id, string title, string description, int mainAuthorId, List<int> coauthorIds)
        {
            if (coauthorIds.Contains(mainAuthorId))
                throw new Exception("Главный автор не может быть еще и соавтором");

            if (coauthorIds.Count() != coauthorIds.Distinct().Count())
                throw new Exception("Присутствуют повторения соавторов");

            var existingBook = await _context.Books
                .Include(b => b.BookAuthors)
                .FirstOrDefaultAsync(b => b.Id == id);

            if (existingBook == null)
                throw new ArgumentException($"Книга с таким id:{id} не найдена");

            // Обновление основных полей книги
            existingBook.Title = title;
            existingBook.Description = description;
            existingBook.MainAuthorId = mainAuthorId;

            // Обновление авторов книги
            var bookAuthors = coauthorIds.Select(id => new BookAuthorEntity { AuthorId = id }).ToList();
            _context.BookAuthorEntity.RemoveRange(existingBook.BookAuthors);
            existingBook.BookAuthors = bookAuthors;

            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            await _context.Books
                .Where(b => b.Id == id)
                .ExecuteDeleteAsync();
        }
    }
}
