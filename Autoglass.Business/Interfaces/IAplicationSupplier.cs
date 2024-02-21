using Autoglass.Domain.Models;

namespace Autoglass.Business.Interfaces;

public interface IAplicationSupplier
{
	Task<bool> CreateSupplier(string description, string cpnj);
	Task<bool> ExistsSupplier(Guid supplierId);
	Task<Supplier> GetSupplierById(Guid supplierId);
}
