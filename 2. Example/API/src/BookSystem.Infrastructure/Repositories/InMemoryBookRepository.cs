
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookSystem.Domain.Entities;
using BookSystem.Domain.Ports;

namespace BookSystem.Infrastructure.Repositories;

public class InMemoryBookRepository : IBookRepository
{
    private readonly List<Book> _books = new();

    public Task AddAsync(Book book)
    {
        _books.Add(book);
        return Task.CompletedTask;
    }

    public Task<Book?> GetByIdAsync(Guid id)
    {
        var book = _books.FirstOrDefault(b => b.Id == id);
        return Task.FromResult(book);
    }

    public Task<IEnumerable<Book>> GetAllAsync()
    {
        return Task.FromResult<IEnumerable<Book>>(_books.ToList());
    }
}
