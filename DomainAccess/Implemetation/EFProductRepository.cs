using Domain.Entities;
using DomainAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DomainAccess.Implemetation
{
    public class EFProductRepository : IProductRepository
    {
        private readonly EFContext _context;
        private readonly MessageBuilder _builder;
        public EFProductRepository(EFContext context)
        {
            _context = context;
            _builder = new MessageBuilder();
        }
        public async Task<Result> AddProduct(Product product)
        {
            var result = new Result();
            try
            {
                if (product == null)
                    throw new ArgumentNullException(nameof(product));
                await _context.AddAsync<Product>(product);
                await _context.SaveChangesAsync();
                result.IsCompleted = true;
            }
            catch(Exception ex)
            {
                result.Message = _builder.Build(ex.Message, nameof(EFProductRepository), nameof(AddProduct));
                result.IsCompleted = true;
            }
            return result;
        }

        public async Task<Result> DeleteProduct(Guid productId)
        {
            var result = new Result();
            try
            {
                var currentProduct = await _context.Products.FirstAsync(
                    p=>p.Id==productId    
                );
                if (currentProduct == null)
                    throw new ArgumentNullException(nameof(currentProduct));
                _context.Products.Remove(currentProduct);
                await _context.SaveChangesAsync();
                result.IsCompleted = true;
            }
            catch(Exception ex)
            {
                result.Message = _builder.Build(ex.Message, nameof(EFProductRepository), nameof(DeleteProduct));
                result.IsCompleted = false;
            }
            return result;
        }

        public async Task<Result<IEnumerable<Product>>> GetAllProductsOfCurrentStore(Guid storeId)
        {
            var result = new Result<IEnumerable<Product>>();
            try
            {
                result.Data = _context.Products.Where(p=>p.StoreId == storeId);
                result.IsCompleted = true;
            }
            catch(Exception ex)
            {
                result.Message = _builder.Build(ex.Message, nameof(EFProductRepository), nameof(GetAllProductsOfCurrentStore));
                result.IsCompleted = false;
            }
            return result;
        }

        public async Task<Result<Product>> GetCurrentProduct(Guid productId)
        {
            var result = new Result<Product>();
            try
            {
                var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == productId);
                if (product == null)
                    throw new ArgumentNullException(nameof(product));
                result.Data = product;
                result.IsCompleted = true;
            }
            catch(Exception ex)
            {
                result.Message = _builder.Build(ex.Message, nameof(EFProductRepository), nameof(GetCurrentProduct));
                result.IsCompleted = false;
            }
            return result;
        }

        public async Task<Result<Product>> UpdateProductCoast(Guid productId, decimal coast)
        {
            var result = new Result<Product>();
            try
            {
                var currentProduct = await _context.Products.FirstAsync(
                    p => p.Id == productId
                );
                if (currentProduct == null)
                    throw new ArgumentNullException(nameof(currentProduct));
                currentProduct.UpdateCoast(coast);
                _context.Update<Product>(currentProduct);
                await _context.SaveChangesAsync();
                result.Data = currentProduct;
                result.IsCompleted = true;
            }
            catch (Exception ex)
            {
                result.Message = _builder.Build(ex.Message, nameof(EFProductRepository), nameof(UpdateProductCoast));
                result.IsCompleted = false;
            }
            return result;
        }

        public async Task<Result<Product>> UpdateProductDescription(Guid productId, string description)
        {
            var result = new Result<Product>();
            try
            {
                var currentProduct = await _context.Products.FirstAsync(
                    p => p.Id == productId
                );
                if (currentProduct == null)
                    throw new ArgumentNullException(nameof(currentProduct));
                currentProduct.UpdateDescription(description);
                _context.Update<Product>(currentProduct);
                await _context.SaveChangesAsync();
                result.Data = currentProduct;
                result.IsCompleted = true;
            }
            catch (Exception ex)
            {
                result.Message = _builder.Build(ex.Message, nameof(EFProductRepository), nameof(UpdateProductDescription));
                result.IsCompleted = false;
            }
            return result;
        }

        public async Task<Result<Product>> UpdateProductName(Guid productId, string productName)
        {
            var result = new Result<Product>();
            try
            {
                var currentProduct = await _context.Products.FirstAsync(
                    p=>p.Id == productId
                );
                if (currentProduct == null)
                    throw new ArgumentNullException(nameof(currentProduct));
                currentProduct.UpdateProductTitle(productName);
                _context.Update<Product>(currentProduct);
                await _context.SaveChangesAsync();
                result.Data = currentProduct;
                result.IsCompleted = true;
            }
            catch(Exception ex)
            {
                result.Message = _builder.Build(ex.Message, nameof(EFProductRepository), nameof(UpdateProductName));
                result.IsCompleted = false;
            }
            return result;
        }
    }
}
