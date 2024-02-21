using Autoglass.Domain.Models;
using Autoglass.Infra.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Autoglass.Infra.Data;

public class AutoglassContext : DbContext
{
	public AutoglassContext(DbContextOptions<AutoglassContext> options) : base(options) { }

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		//IConfigurationBuilder configuration = new Configura
		//	.SetBasePath(Directory.GetCurrentDirectory())
		//	.AddJsonFile("appsettings.json", false, true)
		//	.Build();

		if (!optionsBuilder.IsConfigured)
		{
			optionsBuilder.UseSqlServer(GetConnectionString());
			base.OnConfiguring(optionsBuilder);
		}

		//optionsBuilder.UseSqlServer(configuration.GetConnectionString("ServerConnection"));
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfiguration(new ProductsConfig());
		modelBuilder.ApplyConfiguration(new SuppliersConfig());

		base.OnModelCreating(modelBuilder);
	}

	public string GetConnectionString()
	{
		string strcon = "Server=(LocalDb)\\MSSQLLocalDB;Database=AutoglassDb;Trusted_Connection=True;MultipleActiveResultSets=true";
		return strcon;
	}

	public DbSet<Product> Products { get; set; }
	public DbSet<Supplier> Suppliers { get; set; }
}
