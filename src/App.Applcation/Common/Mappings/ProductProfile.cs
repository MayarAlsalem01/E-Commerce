using App.Applcation.Dtos.Product;
using App.Applcation.Features.Product.Commands.CreateProduct;
using App.Applcation.Features.Product.Commands.UpdateProduct;
using App.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Applcation.Common.Mappings
{
    public class ProductProfile:Profile
    {
        public ProductProfile()
        {
            CreateMap<Product,ProductResponseDto>().ReverseMap();
            CreateMap<Product,UpdateProductCommand>().ReverseMap();
            CreateMap<Product,CreateProductCommand>().ReverseMap();
            CreateMap<ProductRequsetDto,UpdateProductCommand>().ReverseMap();
            CreateMap<ProductRequsetDto,CreateProductCommand>().ReverseMap();
        }
    }
}
