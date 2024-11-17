using Microsoft.EntityFrameworkCore;
using WebApiFirstDemo.ApplicationDbContext;
using WebApiFirstDemo.Repositories.AuthorRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connection =builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDatabaseContext>(options => options.UseSqlServer(connection));

builder.Services.AddScoped<IAuthorRepo, AuthorRepo>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
