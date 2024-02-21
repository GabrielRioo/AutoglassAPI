using Autoglass.Business.Interfaces;
using Autoglass.Domain.Interfaces;
using Autoglass.Domain.Models;

namespace Autoglass.Aplication.Aplication;

public class AplicationSupplier : IAplicationSupplier
{
	ISupplier _ISuplier;
	public AplicationSupplier(ISupplier iSuplier)
	{
		_ISuplier = iSuplier;
	}

	public async Task<bool> CreateSupplier(string description, string cnpj)
	{
		return await _ISuplier.CreateSupplier(description, cnpj);
	}

	public async Task<bool> ExistsSupplier(Guid supplierId)
	{
		return await _ISuplier.ExistsSupplier(supplierId);
	}

	public async Task<Supplier> GetSupplierById(Guid supplierId)
	{
		return await _ISuplier.GetSupplierById(supplierId);
	}
}
