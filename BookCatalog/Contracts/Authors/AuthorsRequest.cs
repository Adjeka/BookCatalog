namespace BookCatalog.Contracts.Authors
{
    public record class AuthorsRequest(
        string LastName,
        string FirstName);
}
