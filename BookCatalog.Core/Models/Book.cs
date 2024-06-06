using System.ComponentModel.DataAnnotations;

namespace BookCatalog.Core.Models
{
    public class Book
    {
        public const int MAX_TITLE_LENGTH = 50;
        public const int MAX_DESCRIPTION_LENGTH = 500;

        private Book(int id, string title, string description, int mainAuthorId, List<Author> coauthors)
        {
            Id = id;
            Title = title;
            Description = description;
            MainAuthorId = mainAuthorId;
            Coauthors = coauthors;
        }

        public int Id { get; }
        public string Title { get; }
        public string Description { get; }
        public int MainAuthorId { get; }

        public List<Author> Coauthors { get; set; }


        public static Book Create(int id, string title, string description, int mainAuthorId, List<Author> coauthors)
        {
            if (string.IsNullOrEmpty(title))
                throw new ArgumentNullException(nameof(title));
            else if (title.Length > MAX_TITLE_LENGTH)
                throw new ArgumentOutOfRangeException($"Название книги не должно быть больше {MAX_TITLE_LENGTH} символов");

            if (string.IsNullOrEmpty(description))
                throw new ArgumentNullException(nameof(description));
            else if (title.Length > MAX_DESCRIPTION_LENGTH)
                throw new ArgumentOutOfRangeException($"Описание книги не должно быть больше {MAX_DESCRIPTION_LENGTH} символов");

            var book = new Book(id, title, description, mainAuthorId, coauthors);

            return book;
        }
    }
}
