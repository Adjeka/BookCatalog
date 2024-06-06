using BookCatalog.Contracts.Authors;
using BookCatalog.Core.Models;

namespace BookCatalog.Contracts.Books
{
    public record class BooksResponse(
        int Id,
        string Title,
        string Description,
        int MainAuthorId,
        List<AuthorsResponse> Coauthors);
}
