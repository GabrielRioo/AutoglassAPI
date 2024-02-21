using Autoglass.Domain.Notifications;
using System.ComponentModel.DataAnnotations.Schema;

namespace Autoglass.Domain.Models;

public class Product : Notify
{
	public Guid ProductId { get; set; }
	public string Description { get; set; }
	public bool Status { get; set; }
	public DateTime ManufacturingDate { get; set; }
	public DateTime ExpiryDate { get; set; }

	[ForeignKey("Supplier")]
	public Guid SupplierId { get; set; }
	public Supplier Supplier { get; set; }
}
