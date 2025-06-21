using Microsoft.EntityFrameworkCore;
using WebApplication1;
using WebApplication1.models;
using WebApplication1.repositorycontent;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


var optionsBuilder = new DbContextOptionsBuilder<Repository>();
optionsBuilder.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
var repository = new Repository(optionsBuilder.Options);
var RecordsService = new RecordsService(repository);

app.UseHttpsRedirection();


app.MapPost("/records", (CreateRecordRequest createRecordRequest) =>
    {
        try
        {
            RecordsService.createRecord(createRecordRequest);
            return Results.Created();
        }
        catch (Exception ex)
        {
            return Results.NotFound();
        }
    })
    .WithName("CreateRecord")
    .WithOpenApi();

app.MapGet("/records", () =>
    {
        try
        {
            var result = RecordsService.getAllRecords();
            return Results.Ok(result);
        }
        catch (Exception ex)
        {
            return Results.NotFound();
        }
    })
    .WithName("AllRecords")
    .WithOpenApi();

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}