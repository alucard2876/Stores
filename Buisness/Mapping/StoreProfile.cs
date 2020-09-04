using AutoMapper;
using Buisness.ViewModels;
using Domain.Entities;

namespace Buisness.Mapping
{
    public class StoreProfile :Profile
    {
        public StoreProfile()
        {
            CreateMap<Store, StoreViewModel>();
            CreateMap<StoreViewModel, Store>().
                ConstructUsing(x => new Store(x.StoreName)).
                ForMember(x => x.Id, y => y.Ignore()).
                ForMember(x=>x.Products,y=>y.Ignore());
        }
    }
}
