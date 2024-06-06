using BookCatalog.Application.Services;
using BookCatalog.Core.Interfaces.Repositories;
using BookCatalog.Core.Interfaces.Services;
using BookCatalog.Infrastructure;
using BookCatalog.Infrastructure.Mapping;
using BookCatalog.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(DataBaseMapping));

builder.Services.AddDbContext<BookCatalogDbContext>(
    options =>
    {
        options.UseNpgsql(builder.Configuration.GetConnectionString(nameof(BookCatalogDbContext)));
    });

builder.Services.AddScoped<IAuthorsService, AuthorsService>();
builder.Services.AddScoped<IAuthorsRepository, AuthorsRepository>();

builder.Services.AddScoped<IBooksService, BooksService>();
builder.Services.AddScoped<IBooksRepository, BooksRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
