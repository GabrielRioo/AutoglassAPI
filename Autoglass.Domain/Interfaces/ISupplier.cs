using Autoglass.Domain.Models;

namespace Autoglass.Domain.Interfaces;

public interface ISupplier
{
	Task<bool> CreateSupplier(string description, string cnpj);
	Task<bool> ExistsSupplier(Guid supplierId);
	Task<Supplier> GetSupplierById(Guid supplierId);
}
