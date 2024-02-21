using System.Linq.Expressions;

namespace Autoglass.Domain.Interfaces.Generics;

public interface IGenerics<T> where T : class
{
	Task<bool> Create(T Object);
	Task<bool> Update(T Object);
	Task<bool> Delete(T Object);
	Task<T> GetById(Guid Id);
	Task<List<T>> GetAll(int pages, int results, Expression<Func<T, bool>> filter = null);
}
