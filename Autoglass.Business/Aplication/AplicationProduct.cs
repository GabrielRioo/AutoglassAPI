using Autoglass.Business.Interfaces;
using Autoglass.Domain.Interfaces;
using Autoglass.Domain.Interfaces.InterfaceServices;
using Autoglass.Domain.Models;
using System.Linq.Expressions;

namespace Autoglass.Business.Aplication;

public class AplicationProduct : IAplicationProduct
{
	IProduct _IProduct;
	IServiceProduct _IServiceProduct;

	public AplicationProduct(IProduct product, IServiceProduct iServiceProduct)
	{
		_IProduct = product;
		_IServiceProduct = iServiceProduct;
	}

	public async Task<bool> CreateProduct(Product product)
	{
		return await _IServiceProduct.CreateProduct(product);
	}

	public async Task<Product> GetProductById(Guid productId)
	{
		return await _IServiceProduct.GetProductById(productId);
	}

	public async Task<List<Product>> GetProducts(int pages, int results, Expression<Func<Product, bool>> filter = null)
	{
		return await _IServiceProduct.GetProducts(pages, results, filter);
	}

	public async Task<bool> UpdateProduct(Product product)
	{
		return await _IServiceProduct.UpdateProduct(product);
	}

	public async Task<bool> DeleteProduct(Product product)
	{
		return await _IServiceProduct.DeleteProduct(product);
	}

	public async Task<bool> ExistsProduct(Guid productId)
	{
		return await _IServiceProduct.ExistsProduct(productId);
	}

	public async Task Create(Product Object)
	{
		await _IProduct.Create(Object);
	}

	public async Task<Product> GetById(Guid Id)
	{
		return await _IProduct.GetById(Id);
	}

	public async Task<List<Product>> GetAll(int pages, int results, Expression<Func<Product, bool>> filter = null)
	{
		return await _IProduct.GetAll(pages, results, filter);
	}

	public async Task Update(Product Object)
	{
		await _IProduct.Update(Object);
	}

	public async Task Delete(Product Object)
	{
		await _IProduct.Delete(Object);
	}
}
