
using System.Linq;
using System.Threading.Tasks;
using BookSystem.Application.UseCases;
using BookSystem.Infrastructure.Repositories;
using Xunit;

namespace BookSystem.UnitTests;

public class CreateBookUseCaseTests
{
    [Fact]
    public async Task Should_Create_Book_Successfully()
    {
        var repo = new InMemoryBookRepository();
        var useCase = new CreateBookUseCase(repo);

        await useCase.ExecuteAsync("Clean Code", "Robert Martin");

        var books = (await repo.GetAllAsync()).ToList();
        Assert.Single(books);
        Assert.Equal("Clean Code", books[0].Title);
    }
}
