using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DomainAccess.Interfaces
{
    public interface IOrderRepository
    {
        Task<Result<IEnumerable<Order>>> GetAllOrders();
        Task<Result<IEnumerable<Order>>> GetUserOrders(Guid userId);
        Task<Result<Order>> GetCurrentOrder(Guid userId, Guid productId);
        Task<Result> DeleteOrder(Guid orderId);
        Task<Result> AddOrder(Order order);
        Task<Result> UpdateOrders(IEnumerable<Order> orders);
    }
}
