using Microsoft.EntityFrameworkCore;
using WebApplication1.models;
using Task = WebApplication1.models.Task;

namespace WebApplication1.repositorycontent;

public class Repository(DbContextOptions<Repository> options) : DbContext(options)
{
    public DbSet<Language> languages { get; set; }
    public DbSet<Record> records { get; set; }
    public DbSet<Student> students { get; set; }
    public DbSet<Task> tasks { get; set; }
    
}