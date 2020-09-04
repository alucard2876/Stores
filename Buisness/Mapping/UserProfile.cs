using AutoMapper;
using Buisness.ViewModels;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Buisness.Mapping
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserViewModel>();
            CreateMap<UserViewModel, User>().
                ConstructUsing(x => new User(x.UserName, x.Password, x.Birthday)).
                ForMember(x=>x.Id,y=>y.Ignore());
        }
    }
}
