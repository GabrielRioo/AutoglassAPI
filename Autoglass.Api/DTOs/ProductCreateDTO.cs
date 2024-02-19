namespace Autoglass.Api.DTOs;

public class ProductCreateDTO
{
	public string Description { get; set; }
	public string Status { get; set; }
	public DateTime ManufacturingDate { get; set; }
	public DateTime ExpiryDate { get; set; }
	public int SupplierId { get; set; }
}
