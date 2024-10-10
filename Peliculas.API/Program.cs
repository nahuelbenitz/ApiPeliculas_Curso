using Microsoft.EntityFrameworkCore;
using Peliculas.API.Data;
using Peliculas.API.Mapper;
using Peliculas.API.Repository;
using Peliculas.API.Repository.Interface;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Contexto de datos
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

//Automapper
builder.Services.AddAutoMapper(typeof(PeliculasProfile));

//Repositories
builder.Services.AddScoped<ICategoriaRepository, CategoriaRepository>();

//Services

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
