
using System.Collections.Generic;
using System.Threading.Tasks;
using BookSystem.Application.UseCases;
using BookSystem.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BookSystem.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase
{
    private readonly CreateBookUseCase _createBook;
    private readonly GetAllBooksUseCase _getAllBooks;

    public BooksController(CreateBookUseCase createBook, GetAllBooksUseCase getAllBooks)
    {
        _createBook = createBook;
        _getAllBooks = getAllBooks;
    }

    [HttpGet]
    public async Task<IEnumerable<Book>> GetAll() => await _getAllBooks.ExecuteAsync();

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] BookDto dto)
    {
        await _createBook.ExecuteAsync(dto.Title, dto.Author);
        return Ok();
    }

    public record BookDto(string Title, string Author);
}
