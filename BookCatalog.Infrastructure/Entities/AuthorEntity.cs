using BookCatalog.Core.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace BookCatalog.Infrastructure.Entities
{
    public class AuthorEntity
    {
        public int Id { get; set; }

        [Required]
        [MinLength(Author.MIN_LENGTH_LASTNAME)]
        [MaxLength(Author.MAX_LENGTH_LASTNAME)]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [MinLength(Author.MIN_LENGTH_FIRSTNAME)]
        [MaxLength(Author.MAX_LENGTH_FIRSTNAME)]
        public string FirstName { get; set; } = string.Empty;

        public List<BookEntity> Books { get; set; } = new();
        public List<BookAuthorEntity> BookAuthors { get; set; } = new();
    }
}
