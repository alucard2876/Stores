using Buisness.Services;
using DomainAccess.Implemetation;
using DomainAccess.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using AutoMapper;
using Buisness.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using DomainAccess;
using Buisness.Mapping;
using Domain.Entities;

namespace Buisness.Configuration
{
    public static class ConfigureServices
    {
        public static void AddLibServices(this IServiceCollection services,string connectionString)
        {
            services.AddDbContext<EFContext>(options => options.UseSqlServer(connectionString));
            services.AddTransient<IUserRepository, EFUserRepository>();
            services.AddTransient<IProductRepository, EFProductRepository>();
            services.AddTransient<IStoreRepository, EFStoreRepository>();
            services.AddTransient<IOrderRepository,EFOrderRepository>();
            services.AddTransient<ILogger, FileLogger>();
            services.AddTransient<UserServise>();
            
        }
        public static void AddMapper(this IServiceCollection services, Type type)
        {
            
            services.AddAutoMapper(cfg=> {
                cfg.AddProfile<UserProfile>();
                cfg.AddProfile<ProductProfile>();
                cfg.AddProfile<StoreProfile>();
                cfg.AddProfile<OrderProfile>();
            });
        }
    }
}
