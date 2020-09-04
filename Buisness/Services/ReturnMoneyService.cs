using DomainAccess;
using DomainAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Buisness.Services
{
    public class ReturnMoneyService
    {
        private readonly IOrderRepository _orderRepos;
        public ReturnMoneyService(IOrderRepository orderRepos)
        {
            _orderRepos = orderRepos;
        }
        public async Task ReturnMoneyFromDeletedStore(Guid productId)
        {
            var orders = await _orderRepos.GetAllOrders();
            
            foreach (var order in orders.Data)
            {
                var amount = 0.0m;
                foreach (var item in order.Products)
                {
                    if(item.Id == productId)  
                        amount += item.Coast;
                    
                }
                order.User.UpdateAmount(amount);
            }
            await _orderRepos.UpdateOrders(orders.Data);
        
        }

        public async Task ReturnMoneyFromStore(Guid storeId)
        {
            var orders = await _orderRepos.GetAllOrders();

            foreach (var order in orders.Data)
            {
                var amount = 0.0m;
                foreach (var item in order.Products)
                {
                    if (item.StoreId == storeId)
                        amount += item.Coast;

                }
                order.User.UpdateAmount(amount);    
            }
            await _orderRepos.UpdateOrders(orders.Data);

        }


    }
}
