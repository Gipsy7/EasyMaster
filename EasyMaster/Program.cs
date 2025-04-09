using EasyMaster.Application;
using EasyMaster.Model.RPG;
using EasyMaster.Repositorio;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add the database context
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register repositories
builder.Services.AddScoped<ISistemaRepositorio, SistemaRepositorio>();
builder.Services.AddScoped<IModuloRepositorio, ModuloRepositorio>();
builder.Services.AddScoped<IComponenteRepositorio, ComponenteRepositorio>();
builder.Services.AddScoped<IPersonagemRepositorio, PersonagemRepositorio>();

// Register application services
builder.Services.AddScoped<ISistemaService, SistemaService>();
builder.Services.AddScoped<IModuloService, ModuloService>();
builder.Services.AddScoped<IComponenteService, ComponenteService>();
builder.Services.AddScoped<IPersonagemService, PersonagemService>();

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
