
using System.Collections.Generic;
using System.Threading.Tasks;
using BookSystem.Domain.Entities;
using BookSystem.Domain.Ports;

namespace BookSystem.Application.UseCases;

public class GetAllBooksUseCase
{
    private readonly IBookRepository _repository;

    public GetAllBooksUseCase(IBookRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Book>> ExecuteAsync()
        => await _repository.GetAllAsync();
}
