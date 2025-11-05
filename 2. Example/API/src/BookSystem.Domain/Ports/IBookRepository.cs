
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookSystem.Domain.Entities;

namespace BookSystem.Domain.Ports;

public interface IBookRepository
{
    Task AddAsync(Book book);
    Task<Book?> GetByIdAsync(Guid id);
    Task<IEnumerable<Book>> GetAllAsync();
}
