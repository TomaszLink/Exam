using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace WebApplication1.repositorycontent;

public class RepositoryContextFactory : IDesignTimeDbContextFactory<Repository>
{
    public Repository CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var optionsBuilder = new DbContextOptionsBuilder<Repository>();
        optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

        return new Repository(optionsBuilder.Options);
    }
}
//dotnet ef migrations add InitialCreate
//dotnet ef database update