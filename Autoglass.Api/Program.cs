using Autoglass.Api.Data;
using Microsoft.EntityFrameworkCore;

namespace Autoglass.Api;

public class Program
{
	public static void Main(string[] args)
	{
		var builder = WebApplication.CreateBuilder(args);

		builder.Services.AddControllers();
		builder.Services.AddEndpointsApiExplorer();
		builder.Services.AddSwaggerGen();
		builder.Services.AddDbContext<AutoglassContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ServerConnection")));
		builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

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
	}
}