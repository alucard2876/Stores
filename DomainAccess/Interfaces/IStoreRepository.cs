using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DomainAccess.Interfaces
{
    public interface IStoreRepository
    {
        Task<Result<Store>> GetCurrentStoreId(Guid storeId);
        Task<Result<IEnumerable<Store>>> GetStoreList();
        Task<Result> AddStore(Store store);
        Task<Result<Store>> UpdateStoreName(Guid storeId,string storeName);
        Task<Result> DeleteStore(Guid storeId);
        Task<Result> AddProductToStore(Product product);
    }
}
