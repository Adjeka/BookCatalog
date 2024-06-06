using BookCatalog.Core.Models;

namespace BookCatalog.Infrastructure.Entities
{
    public class BookAuthorEntity
    {
        public int BookId { get; set; }
        public BookEntity? Book { get; set; }

        public int AuthorId { get; set; }
        public AuthorEntity? Author { get; set; }
    }
}
