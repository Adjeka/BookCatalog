using AutoMapper;
using BookCatalog.Core.Models;
using BookCatalog.Infrastructure.Entities;

namespace BookCatalog.Infrastructure.Mapping
{
    public class DataBaseMapping : Profile
    {
        public DataBaseMapping() 
        {
            CreateMap<BookEntity, Book>();
            CreateMap<AuthorEntity, Author>();
            CreateMap<Author, AuthorEntity>();
        }
    }
}
