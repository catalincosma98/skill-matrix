using Microsoft.EntityFrameworkCore;
using SkillMatrix.Models;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Add the In-Memory Databases
builder.Services.AddDbContext<ApplicationContext>(opt => opt.UseInMemoryDatabase("Languages"));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (builder.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();