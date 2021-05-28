﻿using AutoMapper;
using CFA_API.Entities;
using CFA_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CFA_API.Mapping
{
    public class ProductMappings : Profile
    {
        public ProductMappings()
        {
            CreateMap<ProductModel, Product>()
                .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(scr => scr.Category))
                .ForMember(dest => dest.ProductTypeId, opt => opt.MapFrom(scr => scr.Type))
                .ForMember(dest => dest.BrandId, opt => opt.MapFrom(scr => scr.Brand))
                .ForMember(dest => dest.Colors, opt => opt.Ignore())
                .ForMember(dest => dest.Sizes, opt => opt.Ignore())
                .ForMember(dest => dest.Category, opt => opt.Ignore())
                .ForMember(dest => dest.ProductType, opt => opt.Ignore())
                .ForMember(dest => dest.Brand, opt => opt.Ignore());

            CreateMap<Product, ProductDTO>()
                .ForMember(dest => dest.Category, opt => opt.MapFrom(scr => scr.Category.Name))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(scr => scr.ProductType.Name))
                .ForMember(dest => dest.Brand, opt => opt.MapFrom(scr => scr.Brand.Name))
                .ForMember(dest => dest.Colors, opt => opt.MapFrom(scr => scr.Colors.Select(x => x.Name)))
                .ForMember(dest => dest.Sizes, opt => opt.MapFrom(scr => scr.Sizes.Select(x => x.Name)));
        }
    }
}