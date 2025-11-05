
using BookSystem.Application.UseCases;
using BookSystem.Domain.Ports;
using BookSystem.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IBookRepository, InMemoryBookRepository>();
builder.Services.AddScoped<CreateBookUseCase>();
builder.Services.AddScoped<GetAllBooksUseCase>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();
app.Run();
