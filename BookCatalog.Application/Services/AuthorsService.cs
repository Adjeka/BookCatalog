using BookCatalog.Core.Interfaces.Repositories;
using BookCatalog.Core.Interfaces.Services;
using BookCatalog.Core.Models;

namespace BookCatalog.Application.Services
{
    public class AuthorsService : IAuthorsService
    {
        private readonly IAuthorsRepository _authorsRepository;

        public AuthorsService(IAuthorsRepository authorsRepository)
        {
            _authorsRepository = authorsRepository;
        }

        public async Task<List<Author>> GetAllAuthors()
        {
            return await _authorsRepository.Get();
        }

        public async Task<Author> GetAuthorById(int id)
        {
            return await _authorsRepository.GetById(id);
        }

        public async Task CreateAuthor(Author author)
        {
            await _authorsRepository.Create(author);
        }

        public async Task UpdateAuthor(int id, string lastName, string firstName)
        {
            await _authorsRepository.Update(id, lastName, firstName);
        }

        public async Task DeleteAuthor(int id)
        {
            await _authorsRepository.Delete(id);
        }
    }
}
