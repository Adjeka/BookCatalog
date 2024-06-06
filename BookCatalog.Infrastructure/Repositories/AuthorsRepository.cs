using AutoMapper;
using BookCatalog.Core.Interfaces.Repositories;
using BookCatalog.Core.Models;
using BookCatalog.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookCatalog.Infrastructure.Repositories
{
    public class AuthorsRepository : IAuthorsRepository
    {
        private readonly BookCatalogDbContext _context;
        private readonly IMapper _mapper;

        public AuthorsRepository(BookCatalogDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<Author>> Get()
        {
            var authorEntities = await _context.Authors
                .AsNoTracking()
                .ToListAsync();

            return _mapper.Map<List<Author>>(authorEntities);
        }

        public async Task<Author> GetById(int id)
        {
            var authorEntity = await _context.Authors
                .AsNoTracking()
                .FirstOrDefaultAsync(b => b.Id == id) ?? throw new Exception($"Автор с таким id:{id} не найден");

            return _mapper.Map<Author>(authorEntity);
        }

        public async Task Create(Author author)
        {
            var authorEntity = new AuthorEntity()
            {
                LastName = author.LastName,
                FirstName = author.FirstName
            };

            if (!authorEntity.IsValid())
                throw new Exception("Имя и фамилия должны быть на одном языке.");

            await _context.Authors.AddAsync(authorEntity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(int id, string lastName, string firstName)
        {
            await _context.Authors
                .Where(b => b.Id == id)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(b => b.LastName, lastName)
                    .SetProperty(b => b.FirstName, firstName));
        }

        public async Task Delete(int id)
        {
            await _context.Authors
                .Where(b => b.Id == id)
                .ExecuteDeleteAsync();
        }
    }
}
