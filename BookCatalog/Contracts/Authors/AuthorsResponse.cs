namespace BookCatalog.Contracts.Authors
{
    public record class AuthorsResponse(
        int Id,
        string LastName,
        string FirstName);
}
