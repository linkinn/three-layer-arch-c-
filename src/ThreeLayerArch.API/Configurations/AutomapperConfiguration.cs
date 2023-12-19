using System;
using AutoMapper;
using ThreeLayerArch.API.ViewModels;
using ThreeLayerArch.Business.Models;

namespace ThreeLayerArch.API.Configurations
{
	public class AutomapperConfiguration : Profile
	{
		public AutomapperConfiguration()
		{
			CreateMap<Supplier, SupplierViewModel>().ReverseMap();

            CreateMap<Address, AddressViewModel>().ReverseMap();

            CreateMap<ProductViewModel, Product>();

            CreateMap<Product, ProductViewModel>()
				.ForMember(dest => dest.NameSupplier, opt => opt.MapFrom(src => src.Supplier.Name));
        }
	}
}

