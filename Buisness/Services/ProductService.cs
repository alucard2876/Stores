using AutoMapper;
using Buisness.Logging;
using Buisness.ViewModels;
using Domain.Entities;
using DomainAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Services
{
    public class ProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ReturnMoneyService _moneyService;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public ProductService(IProductRepository productRepository, IMapper mapper, ILogger logger,ReturnMoneyService moneyService)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _logger = logger;
            _moneyService = moneyService;
        }

        public async Task<ProductViewModel> AddProduct(ProductViewModel model)
        {
            var product = _mapper.Map<Product>(model);
            var result = await _productRepository.AddProduct(product);
            if (!result.IsCompleted)
                await _logger.LoggerAsync(result.Message);
            
            return model;
        }
        public async Task<ProductViewModel> UpdateProductName(Guid id,string name)
        {
            var result = await _productRepository.UpdateProductName(id, name);
            if (!result.IsCompleted)
                await _logger.LoggerAsync(result.Message);
            var model = _mapper.Map<ProductViewModel>(result.Data);
            return model;
        }
        public async Task<ProductViewModel> UpdateProductDescription(Guid id, string description)
        {
            var result = await _productRepository.UpdateProductDescription(id, description);
            if (!result.IsCompleted)
                await _logger.LoggerAsync(result.Message);
            var model = _mapper.Map<ProductViewModel>(result.Data);
            return model;
        }
        public async Task<ProductViewModel> UpdateProductCoast(Guid id, decimal coast)
        {
            var result = await _productRepository.UpdateProductCoast(id, coast);
            if (!result.IsCompleted)
                await _logger.LoggerAsync(result.Message);
            var model = _mapper.Map<ProductViewModel>(result.Data);
            return model;
        }
        public async Task<IEnumerable<ProductViewModel>> GetAllProducts(Guid storeId)
        {
            var result = await _productRepository.GetAllProductsOfCurrentStore(storeId);
            if (!result.IsCompleted)
                await _logger.LoggerAsync(result.Message);
            var lst = new List<ProductViewModel>();
            foreach(var product in result.Data)
            {
                lst.Add(_mapper.Map<ProductViewModel>(product));
            }
            return lst;
        }

        public async Task DeleteProduct(Guid id)
        {

        }
    }
}
