using AutoMapper;
using CFA_API.Entities;
using CFA_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CFA_API.Mapping
{
    public class AutoMapperMappings : Profile
    {
        public AutoMapperMappings()
        {
            CreateMap<ProductCreateDTO, Product>()
                .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(scr => scr.Category))
                .ForMember(dest => dest.ProductTypeId, opt => opt.MapFrom(scr => scr.Type))
                .ForMember(dest => dest.BrandId, opt => opt.MapFrom(scr => scr.Brand))
                .ForMember(dest => dest.SupplierId, opt => opt.MapFrom(scr => scr.Supplier))
                .ForMember(dest => dest.Colors, opt => opt.Ignore())
                .ForMember(dest => dest.Sizes, opt => opt.Ignore())
                .ForMember(dest => dest.Category, opt => opt.Ignore())
                .ForMember(dest => dest.ProductType, opt => opt.Ignore())
                .ForMember(dest => dest.Brand, opt => opt.Ignore())
                .ForMember(dest => dest.Supplier, opt => opt.Ignore());


            CreateMap<ProductUpdateDTO, Product>()
                .ForMember(dest => dest.CategoryId, opt => { 
                    opt.PreCondition(scr => scr.Category != null);
                    opt.MapFrom(scr => scr.Category);
                })
                .ForMember(dest => dest.ProductTypeId, opt => {
                    opt.PreCondition(scr => scr.Type != null);
                    opt.MapFrom(scr => scr.Type);
                })
                .ForMember(dest => dest.BrandId, opt => {
                    opt.PreCondition(scr => scr.Brand != null);
                    opt.MapFrom(scr => scr.Brand);
                })
                .ForMember(dest => dest.Price, opt => {
                    opt.PreCondition(scr => scr.Price != null);
                    opt.MapFrom(scr => scr.Price);
                })
                .ForMember(dest => dest.Colors, opt => opt.Ignore())
                .ForMember(dest => dest.Sizes, opt => opt.Ignore())
                .ForMember(dest => dest.Category, opt => opt.Ignore())
                .ForMember(dest => dest.ProductType, opt => opt.Ignore())
                .ForMember(dest => dest.Brand, opt => opt.Ignore())
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Product, ProductResponse>()
                .ForMember(dest => dest.Category, opt => opt.MapFrom(scr => scr.Category.Name))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(scr => scr.ProductType.Name))
                .ForMember(dest => dest.Brand, opt => opt.MapFrom(scr => scr.Brand.Name))
                .ForMember(dest => dest.Colors, opt => opt.MapFrom(scr => scr.Colors.Select(x => x.Name)))
                .ForMember(dest => dest.Sizes, opt => opt.MapFrom(scr => scr.Sizes.Select(x => x.Name)));

            CreateMap<CategoryUpdateDTO, Category>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<ProductTypeUpdateDTO, ProductType>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<BrandUpdateDTO, Brand>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<SupplierUpdateDTO, Supplier>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<ProductColor, ColorSizeResponse>();
            CreateMap<ProductSize, ColorSizeResponse>();
        }
    }
}
