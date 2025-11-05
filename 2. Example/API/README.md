
# BookSystem - Hexagonal Architecture Template (NET 8)

This template demonstrates a Hexagonal (Ports & Adapters) architecture using .NET 8.
Projects included:
- BookSystem.Domain (class library)
- BookSystem.Application (class library)
- BookSystem.Infrastructure (class library)
- BookSystem.Api (Web API)
- BookSystem.UnitTests (xUnit tests)

Run the API:
```bash
dotnet restore
dotnet run --project src/BookSystem.Api/BookSystem.Api.csproj
```

Run tests:
```bash
dotnet test
```

Notes:
- Projects reference each other with project references. You can switch to EF Core, add database providers, or swap the InMemory repository in Infrastructure.
- Keep secrets (API keys, connection strings) out of source control -- use User Secrets or environment variables.
