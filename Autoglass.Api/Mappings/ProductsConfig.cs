using Autoglass.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Autoglass.Api.Mappings;

public class ProductsConfig : IEntityTypeConfiguration<Product>
{
	public void Configure(EntityTypeBuilder<Product> builder)
	{
		builder.HasKey(p => p.ProductId);

		builder.Property(p => p.Description)
			.IsRequired()
			.HasMaxLength(1000);

		builder.Property(p => p.Status)
			.IsRequired();

		builder.HasOne(p => p.Supplier)
			.WithMany(s => s.Products)
			.HasForeignKey(p => p.SupplierId)
			.IsRequired()
			.OnDelete(DeleteBehavior.Cascade);

	}
}
