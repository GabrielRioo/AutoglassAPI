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
	public class ProductController : ControllerBase
	{
		private readonly AutoglassContext _context;
		private readonly IMapper _mapper;
		public ProductController(AutoglassContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		[HttpGet]
		[Route("/products")]
		public async Task<ActionResult> GetProductById(Guid productId)
		{
			var dbProduct = await _context.Products.FindAsync(productId);

			if (dbProduct == null)
				return NotFound();

			return Ok(dbProduct);
		}

		[HttpGet]
		[Route("/products")]
		public async Task<ActionResult> GetProducts()
		{
			return Ok(await _context.Products.ToListAsync());
		}

		[HttpPost]
		[Route("/products")]
		public async Task<ActionResult> CreateProduct([FromBody] ProductCreateDTO productDTO)
		{
			if (productDTO.ManufacturingDate < productDTO.ExpiryDate)
				return BadRequest(new
				{
					success = false,
					message = $"The manufacturing date cannot be smaller than expiry date."
				});

			Product product = _mapper.Map<Product>(productDTO);

			await _context.Products.AddAsync(product);

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

			return Ok(new
			{
				data = productDTO,
				success = true,
				message = $"product created with id: {product.ProductId}"
			});
		}

		[HttpPut]
		[Route("/products")]
		public async Task<ActionResult> UpdateProduct([FromBody] ProductUpdateDTO productDTO)
		{
			if (productDTO.ManufacturingDate < productDTO.ExpiryDate)
				return BadRequest(new
				{
					success = false,
					message = $"The manufacturing date cannot be smaller than expiry date."
				});

			var dbProduct = await _context.Products.FindAsync(productDTO.ProductId);

			if (dbProduct == null)
				return NotFound();
			
			dbProduct.Description = productDTO.Description;
			dbProduct.Status = productDTO.Status;
			dbProduct.ManufacturingDate = productDTO.ManufacturingDate;
			dbProduct.ExpiryDate = productDTO.ExpiryDate;
			dbProduct.SupplierId = productDTO.SupplierId;

			await _context.SaveChangesAsync();

			return Ok(new
			{
				data = productDTO,
				success = true,
				message = $"product with id: {dbProduct.ProductId} updated"
			});
		}

		[HttpDelete]
		[Route("/products")]
		public async Task<ActionResult> DeleteProduct(Guid productId)
		{
			var dbProduct = await _context.Products.FindAsync(productId);

			if (dbProduct == null)
				return NotFound();

			dbProduct.Status = "Inative";
			//_context.Products.Remove(dbProduct);

			await _context.SaveChangesAsync();

			return Ok(new
			{
				success = true,
				message = $"product with id: {dbProduct.ProductId} deleted"
			});
		}
	}
}
