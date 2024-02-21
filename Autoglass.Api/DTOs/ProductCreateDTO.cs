using AutoMapper;

namespace Autoglass.Api.DTOs;

public class ProductCreateDTO
{
	public string Description { get; set; }
	public bool Status { get; set; }
	public DateTime ManufacturingDate { get; set; }
	public DateTime ExpiryDate { get; set; }
	public Guid SupplierId { get; set; }
}
