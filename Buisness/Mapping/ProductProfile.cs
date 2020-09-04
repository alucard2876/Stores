using AutoMapper;
using Buisness.ViewModels;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Buisness.Mapping
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductViewModel>();
            CreateMap<ProductViewModel, Product>().
                ConstructUsing(x=>new Product(x.ProductName,x.MainDescription,x.Coast,x.StoreId)).
                ForMember(x=>x.Id,y=>y.Ignore()).
                ForMember(x=>x.SmallDescription,y=>y.Ignore());
        }
    }
}
