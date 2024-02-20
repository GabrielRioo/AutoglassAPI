using Autoglass.Api.Data;
using Autoglass.Api.DTOs;
using Autoglass.Api.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Autoglass.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SupplierController : ControllerBase
	{
		private readonly AutoglassContext _context;
		private readonly IMapper _mapper;
		public SupplierController(AutoglassContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		[HttpGet]
		[Route("/supplier")]
		public async Task<ActionResult> GetSupplier()
		{
			return Ok(await _context.Suppliers.ToListAsync());
		}

		[HttpPost]
		[Route("/supplier")]
		public async Task<ActionResult> CreateSupplier(SupplierCreateDTO supplierDTO)
		{
			var supplier = _mapper.Map<Supplier>(supplierDTO);

			await _context.Suppliers.AddAsync(supplier);

			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (Exception ex)
			{
				return BadRequest();
			}

			return Ok(supplier);
		}
	}
}
