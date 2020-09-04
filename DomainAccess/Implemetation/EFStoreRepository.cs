using Domain.Entities;
using DomainAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DomainAccess.Implemetation
{
    public class EFStoreRepository : IStoreRepository
    {
        private readonly EFContext _context;
        private readonly MessageBuilder _builder;
        public EFStoreRepository(EFContext context)
        {
            _context = context;
            _builder = new MessageBuilder();
        }
        public async Task<Result> AddStore(Store store)
        {
            var result = new Result();
            try
            {
                if(store == null)
                    throw new ArgumentNullException(nameof(store));
                await _context.AddAsync<Store>(store);
                await _context.SaveChangesAsync();
                result.IsCompleted = true;
            }
            catch(Exception ex)
            {
                result.Message = _builder.Build(ex.Message, nameof(EFStoreRepository), nameof(AddStore));
                result.IsCompleted = true;
            }
            return result;
        }

        public async Task<Result> DeleteStore(Guid storeId)
        {
            var result = new Result();
            try
            {
                var currentStore = await _context.Stores.FirstAsync(
                    s=>s.Id == storeId
                ) ;
                if (currentStore == null)
                    throw new ArgumentNullException(nameof(currentStore));
                _context.Stores.Remove(currentStore);
                await _context.SaveChangesAsync();
                result.IsCompleted = true;
            }
            catch(Exception ex)
            {
                result.Message = _builder.Build(ex.Message, nameof(EFStoreRepository), nameof(DeleteStore));
                result.IsCompleted = false;
            }
            return result;
        }

        public async Task<Result<Store>> GetCurrentStoreId(Guid storeId)
        {
            var result = new Result<Store>(); 
            try
            {
                var currentStore = await _context.Stores.FirstOrDefaultAsync(
                    u=>u.Id==storeId
                    );
                if (currentStore == null)
                    throw new ArgumentNullException(nameof(currentStore));
                result.Data = currentStore;
                result.IsCompleted = true;
            }
            catch(Exception ex)
            {
                result.Message = _builder.Build(ex.Message, nameof(EFStoreRepository), nameof(GetCurrentStoreId));
                result.IsCompleted = false;
            }
            return result;
        }

        public async Task<Result<IEnumerable<Store>>> GetStoreList()
        {
            var result = new Result<IEnumerable<Store>>();
            try
            {
                result.Data = _context.Stores;
                result.IsCompleted = true;
            }
            catch(Exception ex)
            {
                result.Message = _builder.Build(ex.Message, nameof(EFStoreRepository), nameof(GetStoreList));
                result.IsCompleted = false;
            }
            return result;
        }

        public async Task<Result<Store>> UpdateStoreName(Guid storeId, string storeName)
        {
            var result = new Result<Store>();
            try
            {
                var currentStore = await _context.Stores.FirstOrDefaultAsync(
                    s => s.Id == storeId);
                currentStore.UpdateStreTitle(storeName);
                _context.Update(currentStore);
                await _context.SaveChangesAsync();
                result.Data = currentStore;
                result.IsCompleted = true;

            }
            catch(Exception ex)
            {
                result.Message = _builder.Build(ex.Message, nameof(EFStoreRepository), nameof(UpdateStoreName));
                result.IsCompleted = false;
            }
            return result;
        }
        public async Task<Result> AddProductToStore(Product product)
        {
            var result = new Result();
            try
            {
                if (product == null)
                    throw new ArgumentNullException(nameof(product));
                var currentStore = await _context.Stores.FirstAsync(
                    s=>s.Id==product.StoreId
                    );
                if (currentStore == null)
                    throw new ArgumentNullException(nameof(currentStore));
                currentStore.AddProduct(product);
                _context.Update<Store>(currentStore);
                await _context.SaveChangesAsync();
                result.IsCompleted = true;
            }
            catch(Exception ex)
            {
                result.Message = _builder.Build(ex.Message,nameof(EFStoreRepository),nameof(AddProductToStore));
                result.IsCompleted = false;
            }
            return result;
        }


      
    }
}
