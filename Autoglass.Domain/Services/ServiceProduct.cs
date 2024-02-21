using Autoglass.Domain.Interfaces;
using Autoglass.Domain.Interfaces.InterfaceServices;
using Autoglass.Domain.Models;
using System.Linq.Expressions;
using System.Reflection.Metadata;

namespace Autoglass.Domain.Services;

public class ServiceProduct : IServiceProduct
{
	private readonly IProduct _product;
	public ServiceProduct(IProduct product)
	{
		_product = product;
	}

	public async Task<Product> GetProductById(Guid productId)
	{
		return await _product.GetById(productId);
	}

	public async Task<List<Product>> GetProducts(int pages, int results, Expression<Func<Product, bool>> filter = null)
	{
		return await _product.GetProducts(p => p.Status == true);
	}

	public async Task<bool> CreateProduct(Product product)
	{
		var descriptionValidate = product.ValidateStringProperty(product.Description, "Description");
		var dateValidate = product.ValidateDate(product.ManufacturingDate, product.ExpiryDate, "ManufaturingDate");

		if (!dateValidate)
			return false;

		if (descriptionValidate)
		{
			return await _product.Create(product);
		}

		return false;
	}

	public async Task<bool> UpdateProduct(Product product)
	{
		var descriptionValidate = product.ValidateStringProperty(product.Description, "Description");
		var dateValidate = product.ValidateDate(product.ManufacturingDate, product.ExpiryDate, "ManufaturingDate");

		if (descriptionValidate)
		{
			return await _product.Update(product);
		}

		return false;
	}

	public async Task<bool> DeleteProduct(Product product)
	{
		var dbProduct = await _product.GetById(product.ProductId);

		var result = await _product.DeleteProduct(dbProduct);

		if (result)
			return true;
		else
			return false;
	}

	public Task<bool> ExistsProduct(Guid productId)
	{
		throw new NotImplementedException();
	}
}
