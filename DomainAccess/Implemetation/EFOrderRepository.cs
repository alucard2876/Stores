using Domain.Entities;
using DomainAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DomainAccess.Implemetation
{
    public class EFOrderRepository : IOrderRepository
    {
        private readonly EFContext _context;
        private readonly MessageBuilder _builder;
        public EFOrderRepository(EFContext context)
        {
            _context = context;
            _builder = new MessageBuilder();
        }
        public async Task<Result> AddOrder(Order order)
        {
            var result = new Result();
            try
            {
                if (order == null)
                    throw new ArgumentNullException(nameof(order));
                await _context.AddAsync<Order>(order);
                await _context.SaveChangesAsync();
                result.IsCompleted = true;
            }
            catch(Exception ex)
            {
                result.Message = _builder.Build(ex.Message, nameof(EFOrderRepository), nameof(AddOrder));
                result.IsCompleted = false;
            }
            return result;
        }

        public async Task<Result> DeleteOrder(Guid orderId)
        {
            var result = new Result();
            try
            {
                var currentOrder = await _context.Orders.FirstAsync(
                    o=>o.Id == orderId
                );
                if (currentOrder == null)
                    throw new ArgumentNullException(nameof(currentOrder));
                _context.Remove<Order>(currentOrder);
                await _context.SaveChangesAsync();
                result.IsCompleted = true;
            }
            catch(Exception ex)
            {
                result.Message = _builder.Build(ex.Message, nameof(EFOrderRepository), nameof(DeleteOrder));
                result.IsCompleted = true;
            }
            return result;
        }

        public async Task<Result<IEnumerable<Order>>> GetAllOrders()
        {
            var result = new Result<IEnumerable<Order>>();
            try
            {
                var orders = _context.Set<Order>();
                result.Data = await orders.ToListAsync();
                result.IsCompleted = true;
            }
            catch(Exception ex)
            {
                result.Message = _builder.Build(ex.Message, nameof(EFOrderRepository), nameof(GetAllOrders));
                result.IsCompleted = false;
            }
            return result;
        }
        public async Task<Result<IEnumerable<Order>>> GetUserOrders(Guid userId)
        {
            var result = new Result<IEnumerable<Order>>();
            try
            {
                var data = _context.Orders.Where(
                    o=>o.UserId== userId
                );
                if (data == null)
                    throw new ArgumentNullException(nameof(data));
                result.Data = data;
                result.IsCompleted = true;
            }
            catch(Exception ex)
            {
                result.Message = _builder.Build(ex.Message, nameof(EFOrderRepository), nameof(GetAllOrders));
                result.IsCompleted = false;
            }
            return result;
        }

        public async Task<Result<Order>> GetCurrentOrder(Guid userId, Guid productId)
        {
            var result = new Result<Order>();
            try
            {
                var order = await _context.Orders.FirstAsync(
                    o=>o.UserId == userId
                );
                if (order == null)
                    throw new ArgumentNullException(nameof(order));
                result.Data = order;
                result.IsCompleted = true;
            }
            catch(Exception ex)
            {
                result.Message = _builder.Build(ex.Message, nameof(EFOrderRepository), nameof(GetCurrentOrder));
                result.IsCompleted = false;
            }
            return result;
        }

        public async Task<Result> UpdateOrders(IEnumerable<Order> orders)
        {
            var result = new Result();
            try
            {
                if (orders == null)
                    throw new ArgumentNullException(nameof(orders));
                if (orders.Count() == 0)
                    throw new ArgumentOutOfRangeException(nameof(orders));
                _context.UpdateRange(orders);
                await _context.SaveChangesAsync();
                result.IsCompleted = true;

            }
            catch(Exception ex)
            {
                result.Message = _builder.Build(ex.Message, nameof(EFOrderRepository), nameof(UpdateOrders));
                result.IsCompleted = false;
            }
            return result;
        }
    }
}
