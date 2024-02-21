using Autoglass.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Autoglass.Infra.Mappings;

public class SuppliersConfig : IEntityTypeConfiguration<Supplier>
{
	public void Configure(EntityTypeBuilder<Supplier> builder)
	{
		builder.HasKey(s => s.SupplierId);

		builder.Property(s => s.SupplierDescription)
			.HasMaxLength(1000);

		builder.Property(s => s.SupplierCnpj)
			.HasMaxLength(14);

		builder.HasIndex(s => s.SupplierCnpj)
			.IsUnique();

		builder.HasMany(s => s.Products)
			.WithOne(p => p.Supplier)
			.HasForeignKey(p => p.SupplierId)
			.IsRequired();

	}
}
