namespace BookCatalog.Core.Models
{
    public class Author
    {
        public const int MIN_LENGTH_LASTNAME = 2;
        public const int MIN_LENGTH_FIRSTNAME = 2;
        public const int MAX_LENGTH_LASTNAME = 25;
        public const int MAX_LENGTH_FIRSTNAME = 25;

        private Author(int id, string lastName, string firstName)
        {
            Id = id;
            LastName = lastName;
            FirstName = firstName;
        }

        public int Id { get; }
        public string LastName { get; }
        public string FirstName { get; }

        public static Author Create(int id, string lastName, string firstName) 
        {
            if (string.IsNullOrEmpty(lastName))
                throw new ArgumentNullException(nameof(lastName));
            else if (lastName.Length < MIN_LENGTH_LASTNAME || lastName.Length > MAX_LENGTH_LASTNAME )
                throw new ArgumentOutOfRangeException($"Фамилия должна быть не меньше {MIN_LENGTH_LASTNAME} и не больше {MAX_LENGTH_LASTNAME} символов");

            if (string.IsNullOrEmpty(firstName))
                throw new ArgumentNullException(nameof(firstName));
            else if (firstName.Length < MIN_LENGTH_FIRSTNAME || firstName.Length > MAX_LENGTH_FIRSTNAME)
                throw new ArgumentOutOfRangeException($"Имя должно быть не меньше {MIN_LENGTH_FIRSTNAME} и не больше {MAX_LENGTH_FIRSTNAME} символов");

            var author = new Author(id, lastName, firstName);

            return author;
        }
    }
}
