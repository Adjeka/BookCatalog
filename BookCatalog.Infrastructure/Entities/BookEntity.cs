using BookCatalog.Core.Models;
using System.ComponentModel.DataAnnotations;

namespace BookCatalog.Infrastructure.Entities
{
    public class BookEntity
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(Book.MAX_TITLE_LENGTH)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [MaxLength(Book.MAX_DESCRIPTION_LENGTH)]
        public string Description { get; set; } = string.Empty;

        [Required]
        public int MainAuthorId { get; set; }

        public AuthorEntity? MainAuthor { get; set; }

        public List<BookAuthorEntity> BookAuthors { get; set; } = new List<BookAuthorEntity>();
    }
}
