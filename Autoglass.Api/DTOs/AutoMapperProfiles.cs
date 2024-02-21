using Autoglass.Api.Models;
using Autoglass.Domain.Models;
using AutoMapper;

namespace Autoglass.Api.DTOs;

public class AutoMapperProfiles : Profile
{
	public AutoMapperProfiles()
	{
		CreateMap<ProductCreateDTO, Product>();
		CreateMap<ProductUpdateDTO, Product>();
		CreateMap<ProductDeleteDTO, Product>();
		CreateMap<SupplierDTO, Supplier>();
	}
}
