using Autoglass.Domain.Interfaces.Generics;
using Autoglass.Domain.Models;
using System.Linq.Expressions;

namespace Autoglass.Domain.Interfaces;

public interface IProduct : IGenerics<Product>
{
	Task<bool> CreateProduct(Product product);
	Task<bool> ExistsProduct(Guid productId);
	Task<Product> GetProductById(Guid productId);
	Task<List<Product>> GetProducts(Expression<Func<Product, bool>> exProduct);
	Task<bool> UpdateProduct(Product product);
	Task<bool> DeleteProduct(Product product);
}
