using AutoMapper;
using Buisness.Logging;
using Buisness.ViewModels;
using Domain.Entities;
using DomainAccess.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Services
{
    public class StoreService
    {
        private readonly IStoreRepository _storeRepos;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public StoreService(IStoreRepository storeRepos,IMapper mapper,ILogger logger)
        {
            _storeRepos = storeRepos;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<StoreViewModel> AddStore(StoreViewModel model)
        {
            var store =  _mapper.Map<Store>(model);
            var result = await _storeRepos.AddStore(store);
            if (!result.IsCompleted)
            {
                await _logger.LoggerAsync(result.Message);
                return new StoreViewModel();
            }
            return model;
        }
        public async Task<StoreViewModel> UpdateStoreName(Guid storeId,string storeName)
        {
            var result = await _storeRepos.UpdateStoreName(storeId, storeName);
            if (!result.IsCompleted)
                await _logger.LoggerAsync(result.Message);
            var store = _mapper.Map<StoreViewModel>(result.Data);
            return store;
        }
        public async Task AddProduct(Guid storeId,ProductViewModel product)
        {
            var store = await _storeRepos.GetCurrentStoreId(storeId);
            if(!store.IsCompleted)
            {
                await _logger.LoggerAsync(store.Message);
            }
        }
        public async Task<IEnumerable<StoreViewModel>> GetStores()
        {
            var stores = await _storeRepos.GetStoreList();
            if (!stores.IsCompleted)
                await _logger.LoggerAsync(stores.Message);
            var storeList = new List<StoreViewModel>();
            foreach(var store in stores.Data)
            {
                var model = _mapper.Map<StoreViewModel>(store);
                storeList.Add(model);
            }
            return storeList;
        }
    }
}
