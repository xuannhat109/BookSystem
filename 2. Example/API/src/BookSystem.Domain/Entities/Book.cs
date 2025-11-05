
using System;

namespace BookSystem.Domain.Entities;

public class Book
{
    public Guid Id { get; private set; }
    public string Title { get; private set; }
    public string Author { get; private set; }

    public Book(string title, string author)
    {
        Id = Guid.NewGuid();
        Title = title;
        Author = author;
    }
}
