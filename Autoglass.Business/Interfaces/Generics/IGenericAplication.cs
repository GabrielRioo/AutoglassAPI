using System.Linq.Expressions;

namespace Autoglass.Business.Interfaces.Generics;

public interface IGenericAplication<T> where T : class
{
	Task Create(T Object);
	Task Update(T Object);
	Task Delete(T Object);
	Task<T> GetById(Guid Id);
	Task<List<T>> GetAll(int pages, int results, Expression<Func<T, bool>> filter = null);
}
