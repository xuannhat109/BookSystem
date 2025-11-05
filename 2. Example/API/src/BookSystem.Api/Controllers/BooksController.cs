using System.Collections.Generic;
using System.Threading.Tasks;
using BookSystem.Application.UseCases;
using BookSystem.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BookSystem.Api.Controllers;

/// <summary>
/// Controller quản lý sách — ví dụ cho Hexagonal Architecture.
/// </summary>
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

    /// <summary>
    /// Lấy danh sách tất cả sách hiện có.
    /// </summary>
    [HttpGet]
    public async Task<IEnumerable<Book>> GetAll() => await _getAllBooks.ExecuteAsync();

    /// <summary>
    /// Thêm sách mới.
    /// </summary>
    /// <param name="dto">Thông tin sách</param>
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] BookDto dto)
    {
        await _createBook.ExecuteAsync(dto.Title, dto.Author);
        return Ok();
    }

    public record BookDto(string Title, string Author);
}
