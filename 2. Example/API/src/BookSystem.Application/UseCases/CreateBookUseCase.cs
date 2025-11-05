
using System.Threading.Tasks;
using BookSystem.Domain.Entities;
using BookSystem.Domain.Ports;

namespace BookSystem.Application.UseCases;

public class CreateBookUseCase
{
    private readonly IBookRepository _repository;

    public CreateBookUseCase(IBookRepository repository)
    {
        _repository = repository;
    }

    public async Task ExecuteAsync(string title, string author)
    {
        var book = new Book(title, author);
        await _repository.AddAsync(book);
    }
}
