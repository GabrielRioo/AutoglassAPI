using Autoglass.Api.Models;
using Autoglass.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Autoglass.Api.Controllers
{
	[Route("api/[controller")]
	[ApiController]
	public class SupplierController : ControllerBase
	{
		private readonly IAplicationSupplier _IAplicationSupplier;

		public SupplierController(IAplicationSupplier iAplicationSupplier)
		{
			_IAplicationSupplier = iAplicationSupplier;
		}

		[HttpGet("/api/CreateSupplier")]
		public async Task<IActionResult> GetSupplierById(Guid supplierId)
		{
			var supplierExist = await _IAplicationSupplier.ExistsSupplier(supplierId);
			if (supplierExist)
			{
				var result = await _IAplicationSupplier.GetSupplierById(supplierId);
				return Ok(result);
			}
			else
			{
				return BadRequest("Suppier doen't exists");
			}

		}

		[HttpPost("/api/CreateSupplier")]
		public async Task<IActionResult> CreateSupplier([FromBody] SupplierDTO supplierDTO)
		{
			if (string.IsNullOrWhiteSpace(supplierDTO.SupplierDescription) || string.IsNullOrWhiteSpace(supplierDTO.SupplierCnpj))
				return BadRequest("All fields are required");

			var result = await _IAplicationSupplier.CreateSupplier(supplierDTO.SupplierDescription, supplierDTO.SupplierCnpj);

			if (result)
				return Ok("Supplier successfully created");
			else
				return BadRequest("Error to create supplier");
		}
	}
}
