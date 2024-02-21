using Autoglass.Aplication.Aplication;
using Autoglass.Business.Aplication;
using Autoglass.Business.Interfaces;
using Autoglass.Domain.Interfaces;
using Autoglass.Domain.Interfaces.Generics;
using Autoglass.Domain.Interfaces.InterfaceServices;
using Autoglass.Domain.Services;
using Autoglass.Infra.Data;
using Autoglass.Infra.Repository;
using Autoglass.Infra.Repository.Generics;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AutoglassContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ServerConnection")));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Interface e repositorio
builder.Services.AddSingleton(typeof(IGenerics<>), typeof(GenericRepository<>));
builder.Services.AddSingleton<IProduct, ProductRepository>();
builder.Services.AddSingleton<ISupplier, SupplierRepository>();

// Servico Dominio
builder.Services.AddSingleton<IServiceProduct, ServiceProduct>();

// Interface Aplicação
builder.Services.AddSingleton<IAplicationProduct, AplicationProduct>();
builder.Services.AddSingleton<IAplicationSupplier, AplicationSupplier>();

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
