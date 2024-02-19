namespace Autoglass.Api.Models;

public class Supplier
{
	public int SupplierCode { get; set; }
	public string SupplierDescription { get; set; }
	public string SupplierCnpj { get; set; }

	public ICollection<Product> Products { get; set; }
}
