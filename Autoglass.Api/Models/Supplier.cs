namespace Autoglass.Api.Models;

public class Supplier
{
	public Guid SupplierId { get; set; }
	public string SupplierDescription { get; set; }
	public string SupplierCnpj { get; set; }

	public ICollection<Product> Products { get; set; }
}
