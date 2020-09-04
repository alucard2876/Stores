using AutoMapper;
using Buisness.ViewModels;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Buisness.Mapping
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order,OrderViewModel>();
            
            CreateMap<OrderViewModel, Order>().
                ConstructUsing(x=>new Order(x.Description,x.UserId,x.Products)).
                ForMember(x=>x.Id,y=>y.Ignore()).
                ForMember(x=>x.Products,y=>y.Ignore());
        }
    }
}
