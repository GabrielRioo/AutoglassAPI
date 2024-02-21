using Autoglass.Domain.Interfaces.Generics;
using Autoglass.Domain.Models;
using Autoglass.Infra.Data;
using Azure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32.SafeHandles;
using System.Linq.Expressions;
using System.Runtime.InteropServices;

namespace Autoglass.Infra.Repository.Generics;

public class GenericRepository<T> : IGenerics<T>, IDisposable where T : class
{
	private readonly DbContextOptions<AutoglassContext> _OptionsBuilder;

	public GenericRepository()
	{
		_OptionsBuilder = new DbContextOptions<AutoglassContext>();
	}


	public async Task<bool> Create(T Object)
	{
		using (var data = new AutoglassContext(_OptionsBuilder))
		{
			await data.Set<T>().AddAsync(Object);
			await data.SaveChangesAsync();

			return true;
		}
	}

	public async Task<bool> Update(T Object)
	{
		using (var data = new AutoglassContext(_OptionsBuilder))
		{
			data.Set<T>().Update(Object);
			await data.SaveChangesAsync();

			return true;
		}
	}

	public async Task<T> GetById(Guid Id)
	{
		using (var data = new AutoglassContext(_OptionsBuilder))
		{
			return await data.Set<T>().FindAsync(Id);
		}
	}

	public async Task<List<T>> GetAll(int pages, int results, Expression<Func<T, bool>> filter = null)
	{
		using (var data = new AutoglassContext(_OptionsBuilder))
		{
			IQueryable<T> query = data.Set<T>().AsNoTracking();

			if (filter != null)
			{
				query = query.Where(filter).Skip((pages - 1) * results).Take(results);
			}

			return await query.ToListAsync();
		}
	}

	public async Task<bool> Delete(T Object)
	{
		using (var data = new AutoglassContext(_OptionsBuilder))
		{
			data.Set<T>().Remove(Object);
			await data.SaveChangesAsync();

			return true;
		}
	}

	bool disposed = false;
	SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);
	public void Dispose()
	{
		Dispose(true);
		GC.SuppressFinalize(this);
	}

	protected virtual void Dispose(bool disposing)
	{
		if (disposed)
			return;

		if (disposing)
			handle.Dispose();

		disposed = true;
	}
}
