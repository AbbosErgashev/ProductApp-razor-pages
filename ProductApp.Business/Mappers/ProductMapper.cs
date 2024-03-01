using AutoMapper;
using ProductApp.Business.Models.ProductModel;
using ProductApp.Infrastructure.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApp.Business.Mappers
{
    public class ProductMapper : Profile
    {
        public ProductMapper()
        {
            CreateMap<Product, CreateProductModel>().ReverseMap();
            CreateMap<Product, ReadProductModel>().ReverseMap();
            CreateMap<Product, UpdateProductModel>().ReverseMap();
        }
    }
}
