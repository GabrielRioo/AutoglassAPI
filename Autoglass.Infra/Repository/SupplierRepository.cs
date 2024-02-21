using Autoglass.Domain.Interfaces;
using Autoglass.Domain.Models;
using Autoglass.Infra.Data;
using Autoglass.Infra.Repository.Generics;
using Microsoft.EntityFrameworkCore;

namespace Autoglass.Infra.Repository;

public class SupplierRepository : GenericRepository<Supplier>, ISupplier
{
	private readonly DbContextOptions<AutoglassContext> _optionsBuilder;
	public SupplierRepository()
	{
		_optionsBuilder = new DbContextOptions<AutoglassContext>();
	}

	public async Task<bool> CreateSupplier(string description, string cpnj)
	{
		try
		{
			using (var data = new AutoglassContext(_optionsBuilder))
			{
				await data.Suppliers.AddAsync(
					new Supplier
					{
						SupplierDescription = description,
						SupplierCnpj = cpnj
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

	public async Task<bool> ExistsSupplier(Guid supplierId)
	{
		try
		{
			using (var data = new AutoglassContext(_optionsBuilder))
			{
				return await data.Suppliers.Where(s => s.SupplierId.Equals(supplierId)).AsNoTracking().AnyAsync();
			}
		}
		catch (Exception)
		{
			return false;
		}
	}

	public async Task<Supplier> GetSupplierById(Guid supplierId)
	{
		try
		{
			using (var data = new AutoglassContext(_optionsBuilder))
			{
				return await data.Suppliers.FindAsync(supplierId);
			}
		}
		catch (Exception)
		{
			return null;
		}
	}

}
