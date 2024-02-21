using Autoglass.Domain.Models;
using System.Linq.Expressions;

namespace Autoglass.Domain.Interfaces.InterfaceServices;

public interface IServiceProduct
{
	Task<bool> CreateProduct(Product product);
	Task<bool> UpdateProduct(Product product);
	Task<Product> GetProductById(Guid productId);
	Task<List<Product>> GetProducts(int pages, int results, Expression<Func<Product, bool>> filter = null);
	Task<bool> DeleteProduct(Product product);
	Task<bool> ExistsProduct(Guid productId);
}
