using Autoglass.Api.DTOs;
using Autoglass.Api.Models;
using AutoMapper;

namespace Autoglass.Api.Mappings;

public class AutoMapperProfiles : Profile
{
	public AutoMapperProfiles()
	{
		CreateMap<ProductCreateDTO, Product>();
		CreateMap<SupplierCreateDTO, Supplier>();
	} 
}
