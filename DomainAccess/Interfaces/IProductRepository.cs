using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DomainAccess.Interfaces
{
    public interface IProductRepository
    {
        Task<Result<IEnumerable<Product>>> GetAllProductsOfCurrentStore(Guid storeId);
        Task<Result<Product>> GetCurrentProduct(Guid productId);
        Task<Result> AddProduct(Product product);
        Task<Result<Product>> UpdateProductName(Guid productId,string productName);
        Task<Result<Product>> UpdateProductDescription(Guid productId,string description);
        Task<Result<Product>> UpdateProductCoast(Guid productId,decimal coast);
        Task<Result> DeleteProduct(Guid productId);

    }
}
