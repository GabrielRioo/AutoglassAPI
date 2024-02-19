using Autoglass.Api.Mappings;
using Autoglass.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Autoglass.Api.Data;

public class AutoglassContext : DbContext
{
	public AutoglassContext(DbContextOptions<AutoglassContext> options) 
		: base(options)	{ }

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		IConfiguration configuration = new ConfigurationBuilder()
			.SetBasePath(Directory.GetCurrentDirectory())
			.AddJsonFile("appsettings.json", false, true)
			.Build();

		optionsBuilder.UseSqlServer(configuration.GetConnectionString("ServerConnection"));
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfiguration(new ProductsConfig());
		modelBuilder.ApplyConfiguration(new SupplierConfig());

		base.OnModelCreating(modelBuilder);
	}

	public DbSet<Product> Products { get; set; }
	public DbSet<Supplier> Suppliers { get; set; }
}
