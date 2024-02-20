namespace Autoglass.Api.DTOs;

public class ProductUpdateDTO
{
	public Guid ProductId { get; set; }
	public string Description { get; set; }
	public string Status { get; set; }
	public DateTime ManufacturingDate { get; set; }
	public DateTime ExpiryDate { get; set; }
	public Guid SupplierId { get; set; }
}
