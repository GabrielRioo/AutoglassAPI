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
		public async Task<ActionResult> GetProducts()
		{
			return Ok(await _context.Products.ToListAsync());
		}

		[HttpPost]
		[Route("/products")]
		public async Task<ActionResult> CreateProduct(ProductCreateDTO productDTO)
		{
			var product = _mapper.Map<Product>(productDTO);

			await _context.Products.AddAsync(product);
			await _context.SaveChangesAsync();

			return Ok(product);
		}
	}
}
