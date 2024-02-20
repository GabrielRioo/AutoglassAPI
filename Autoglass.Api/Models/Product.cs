﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Autoglass.Api.Models;

public class Product
{
	public Guid ProductId { get; set; }
	public string Description { get; set; }
	public string Status { get; set; }
	public DateTime ManufacturingDate { get; set; }
	public DateTime ExpiryDate { get; set; }

	[ForeignKey("Supplier")]
	public Guid SupplierId { get; set; }
	public Supplier Supplier { get; set; }

}
