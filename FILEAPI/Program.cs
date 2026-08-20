using FILEAPI.Data.Database;
using FILEAPI.Middleware;
using FILEAPI.Repository;
using FILEAPI.Repository.Interfaces;
using FILEAPI.Services;
using FILEAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

#region Database Connection

builder.Services.AddDbContext<AppDbContext>((options) =>

     options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
);
#endregion

#region Dependency Injection

builder.Services.AddScoped<IAuthorRepository,AuthorRepository>();
builder.Services.AddScoped<IAuthorService, AuthorService>();
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseMiddleware<ExceptionHandlerMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
