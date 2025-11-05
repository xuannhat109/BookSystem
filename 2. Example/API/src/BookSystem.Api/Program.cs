using System.Reflection;
using BookSystem.Application.UseCases;
using BookSystem.Domain.Ports;
using BookSystem.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// ---------------------
// Register dependencies
// ---------------------
builder.Services.AddScoped<IBookRepository, InMemoryBookRepository>();
builder.Services.AddScoped<CreateBookUseCase>();
builder.Services.AddScoped<GetAllBooksUseCase>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// ---------------------
// Swagger configuration
// ---------------------
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Version = "v1",
        Title = "Book System API",
        Description = "API for managing books (Hexagonal Architecture Example)",
        Contact = new Microsoft.OpenApi.Models.OpenApiContact
        {
            Name = "Book System Team",
            Email = "support@booksystem.local",
            Url = new Uri("https://github.com/xuannhat109/BookSystem")
        },
        License = new Microsoft.OpenApi.Models.OpenApiLicense
        {
            Name = "MIT License",
            Url = new Uri("https://opensource.org/licenses/MIT")
        }
    });

    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFilename);
    if (File.Exists(xmlPath))
        options.IncludeXmlComments(xmlPath);
});

var app = builder.Build();

// ---------------------
// Middleware pipeline
// ---------------------
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Book System API v1");
        options.RoutePrefix = string.Empty;
    });
}
else
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Book System API v1");
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
