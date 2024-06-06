using BookCatalog.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookCatalog.Infrastructure
{
    public class BookCatalogDbContext : DbContext
    {
        public BookCatalogDbContext(DbContextOptions<BookCatalogDbContext> options)
            : base(options)
        {
        }

        public DbSet<BookEntity> Books { get; set; }
        public DbSet<AuthorEntity> Authors { get; set; }
        public DbSet<BookAuthorEntity> BookAuthorEntity { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<BookEntity>()
                .HasOne(b => b.MainAuthor)
                .WithMany(a => a.Books)
                .HasForeignKey(b => b.MainAuthorId);

            modelBuilder.Entity<BookAuthorEntity>()
                .ToTable("BookAuthor")
                .HasKey(ba => new { ba.BookId, ba.AuthorId });

            modelBuilder.Entity<BookAuthorEntity>()
                .HasOne(ba => ba.Book)
                .WithMany(b => b.BookAuthors)
                .HasForeignKey(ba => ba.BookId);

            modelBuilder.Entity<BookAuthorEntity>()
                .HasOne(ba => ba.Author)
                .WithMany(a => a.BookAuthors)
                .HasForeignKey(ba => ba.AuthorId);
        }
    }
}
