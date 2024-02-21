using Autoglass.Api.DTOs;
using Autoglass.Api.Models;
using Autoglass.Business.Interfaces;
using Autoglass.Domain.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Autoglass.Api.Controllers
{
	[Route("api/[controller")]
	[ApiController]
	public class ProductController : ControllerBase
	{
		private readonly IAplicationProduct _IAplicationProduct;
		private readonly IMapper _mapper;

		public ProductController(IAplicationProduct IAplicationProduct, IMapper mapper)
		{
			_IAplicationProduct = IAplicationProduct;
			_mapper = mapper;
		}

		[HttpGet("/api/GetProduct")]
		public async Task<IActionResult> GetProductById(Guid productId)
		{
			//var productExist = await _IAplicationProduct.ExistsProduct(productId);

			var result = await _IAplicationProduct.GetProductById(productId);

			if (result != null)
				return Ok(result);
			else
				return BadRequest("Product doen't exists");
		}

		[HttpGet("/api/GetAllProduct")]
		public async Task<IActionResult> GetAllProducts(
			[FromQuery] string? description,
			[FromQuery] bool? status,
			[FromQuery] int pages = 1,
			[FromQuery] int pageSize = 2)
		{
			Expression<Func<Product, bool>> filter = p => true;

			if (!string.IsNullOrEmpty(description))
				filter = p => p.Description == description;
			else if (status.HasValue)
				filter = p => p.Status == status;
			else if(!string.IsNullOrEmpty(description) && status.HasValue)
				filter = p => p.Description == description || p.Status == status;

			//Expression<Func<Product, bool>> filter = p => p.Description == description || p.Status == status;
			var result = await _IAplicationProduct.GetAll(pages, pageSize ,filter);

			if (result != null)
				return Ok(result);
			else
				return BadRequest("Product doen't exists");
		}

		[HttpPost("/api/CreateProduct")]
		public async Task<IActionResult> CreateProduct([FromBody] ProductCreateDTO productDTO)
		{
			if (string.IsNullOrWhiteSpace(productDTO.Description))
				return BadRequest("All fields are required");

			Product product = _mapper.Map<Product>(productDTO);

			var result = await _IAplicationProduct.CreateProduct(product);

			if (result)
				return Ok("Product successfully created");
			else
				return BadRequest("Error to create product");
		}

		[HttpPut("/api/UpdateProduct")]
		public async Task<IActionResult> UpdateProduct([FromBody] ProductUpdateDTO productDTO)
		{
			Product product = _mapper.Map<Product>(productDTO);

			var result = await _IAplicationProduct.UpdateProduct(product);

			if (result)
				return Ok("Product successfully updated");
			else
				return BadRequest("Error to update product");
		}

		[HttpDelete("/api/DeleteProduct")]
		public async Task<IActionResult> DeleteProduct(ProductDeleteDTO productDTO)
		{
			Product product = _mapper.Map<Product>(productDTO);

			var result = await _IAplicationProduct.DeleteProduct(product);

			if (result)
				return Ok("Product successfully deleted");
			else
				return BadRequest("Error to delete product");
		}
	}
}
