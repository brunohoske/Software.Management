﻿using AutoMapper;
using Tablefy.Api.Entities;
using Tablefy.Api.Models;

namespace Tablefy.Api.Data.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<CompanyProductEntity, CompanyProductModel>();
            // Mapeamento direto
            CreateMap<ProductEntity, ProductSimpleModel>()
                .ForMember(dest => dest.CompanyId, opt => opt.MapFrom(src => src.CompanyProducts.Select(cp => cp.CompanyId).FirstOrDefault()))
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.CompanyProducts.Select(pc => pc.ProductId).FirstOrDefault()))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.CompanyProducts.Select(pc => pc.Price).FirstOrDefault()))
                .ForMember(dest => dest.Active, opt => opt.MapFrom(src => src.CompanyProducts.Select(pc => pc.Active).FirstOrDefault()))
                .ForMember(dest => dest.SaleProduct, opt => opt.MapFrom(src => src.CompanyProducts.Select(pc => pc.SaleProduct).FirstOrDefault()))
                .ForMember(dest => dest.PercentageDiscount, opt => opt.MapFrom(src => src.CompanyProducts.Select(pc => pc.PercentageDiscount).FirstOrDefault()))
                .ForMember(dest => dest.ValueDiscount, opt => opt.MapFrom(src => src.CompanyProducts.Select(pc => pc.ValueDiscount).FirstOrDefault()));
            CreateMap<IngredientEntity, IngredientModel>();

            CreateMap<ProductSidesEntity, ProductSideModel>()
                .ForMember(dest => dest.Side, opt => opt.MapFrom(src => src.Side));

            CreateMap<SelectionGroupProductEntity, SelectionGroupProductModel>()
                .ForMember(dest => dest.Product, opt => opt.MapFrom(src => src.Product))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price));

            CreateMap<SelectionGroupEntity, SelectionGroupModel>()
                .ForMember(dest => dest.SelectionGroupProducts, opt => opt.MapFrom(src => src.SelectionGroupProducts));


            CreateMap<ProductEntity, ProductExtrasModel>()
                .ForMember(dest => dest.Recommendations, opt => opt.MapFrom(src => src.ProductRecommendations.Select(cp => cp.Product)))
                .ForMember(dest => dest.Sides, opt => opt.MapFrom(src => src.ProductsSides))
                .ForMember(dest => dest.Ingredients, opt => opt.MapFrom(src => src.ProductIngredients.Select(cp => cp.Ingredient)))
                .ForMember(dest => dest.SelectionGroups, opt => opt.MapFrom(src => src.SelectionGroupProducts.Select(cp => cp.SelectionGroup)));

            CreateMap<ProductEntity, ProductCompleteModel>()
                .ForMember(dest => dest.CompanyId, opt => opt.MapFrom(src => src.CompanyProducts.Select(cp => cp.CompanyId).FirstOrDefault()))
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.CompanyProducts.Select(pc => pc.ProductId).FirstOrDefault()))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.CompanyProducts.Select(pc => pc.Price).FirstOrDefault()))
                .ForMember(dest => dest.Active, opt => opt.MapFrom(src => src.CompanyProducts.Select(pc => pc.Active).FirstOrDefault()))
                .ForMember(dest => dest.SaleProduct, opt => opt.MapFrom(src => src.CompanyProducts.Select(pc => pc.SaleProduct).FirstOrDefault()))
                .ForMember(dest => dest.PercentageDiscount, opt => opt.MapFrom(src => src.CompanyProducts.Select(pc => pc.PercentageDiscount).FirstOrDefault()))
                .ForMember(dest => dest.ValueDiscount, opt => opt.MapFrom(src => src.CompanyProducts.Select(pc => pc.ValueDiscount).FirstOrDefault()))
                .ForMember(dest => dest.Extras, opt => opt.MapFrom(src => src));
                

            CreateMap<CategoryEntity, DisplayCatalogModel>()
                .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.ProductCategories.Select(pc => pc.Product)));
    }
    }

}
