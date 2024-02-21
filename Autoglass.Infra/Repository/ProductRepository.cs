using Autoglass.Domain.Interfaces;
using Autoglass.Domain.Models;
using Autoglass.Infra.Data;
using Autoglass.Infra.Repository.Generics;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Autoglass.Infra.Repository;

public class ProductRepository : GenericRepository<Product>, IProduct
{
	private readonly DbContextOptions<AutoglassContext> _optionsBuilder;
	public ProductRepository()
	{
		_optionsBuilder = new DbContextOptions<AutoglassContext>();
	}

	public async Task<bool> CreateProduct(Product product)
	{
		try
		{
			using (var data = new AutoglassContext(_optionsBuilder))
			{
				await data.Products.AddAsync(
					new Product
					{
						Description = product.Description,
						Status = product.Status,
						ManufacturingDate = product.ManufacturingDate,
						ExpiryDate = product.ExpiryDate,
						SupplierId = product.SupplierId,
					});

				await data.SaveChangesAsync();
			}
		}
		catch (Exception)
		{
			return false;
		}

		return true;
	}

	public async Task<bool> UpdateProduct(Product product)
	{
		try
		{
			using (var data = new AutoglassContext(_optionsBuilder))
			{
				data.Products.Update(product);

				await data.SaveChangesAsync();
			}
		}
		catch (Exception)
		{
			return false;
		}

		return true;
	}

	public async Task<bool> DeleteProduct(Product product)
	{
		try
		{
			using (var data = new AutoglassContext(_optionsBuilder))
			{
				//data.Products.Remove(product);
				product.Status = false;
				data.Products.Update(product);

				await data.SaveChangesAsync();
			}
		}
		catch (Exception ex)
		{
			return false;
		}

		return true;
	}

	public async Task<bool> ExistsProduct(Guid productId)
	{
		try
		{
			using (var data = new AutoglassContext(_optionsBuilder))
			{
				return await data.Products.Where(s => s.ProductId.Equals(productId)).AsNoTracking().AnyAsync();
			}
		}
		catch (Exception)
		{
			return false;
		}
	}

	public async Task<Product> GetProductById(Guid productId)
	{
		using (var data = new AutoglassContext(_optionsBuilder))
		{
			return await data.Products.FindAsync(productId);
		}
	}

	public async Task<List<Product>> GetProducts(Expression<Func<Product, bool>> exProduct)
	{
		using (var data = new AutoglassContext(_optionsBuilder))
		{
			return await data.Products.Where(exProduct).AsNoTracking().ToListAsync();
		}
	}


}
