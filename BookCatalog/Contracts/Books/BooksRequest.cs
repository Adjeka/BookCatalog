using BookCatalog.Core.Models;

namespace BookCatalog.Contracts.Books
{
    public record class BooksRequest(
        string Title,
        string Description,
        int MainAuthorId,
        List<int> CoauthorIds);
}
