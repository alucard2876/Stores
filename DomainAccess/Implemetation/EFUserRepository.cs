using Domain.Entities;
using DomainAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace DomainAccess.Implemetation
{
    public class EFUserRepository : IUserRepository
    {
        private readonly EFContext _context;
        private readonly MessageBuilder _builder;
        public EFUserRepository(EFContext context)
        {
            _context = context;
            _builder = new MessageBuilder();

        }
        public async Task<Result> AddUser(User user)
        {
            var result = new Result();
            try
            {
                if (user == null)
                    throw new ArgumentNullException(nameof(user));
                await _context.AddAsync<User>(user);
                var operationResult = await _context.SaveChangesAsync();
                if (operationResult != 1)
                    throw new OperationCanceledException(nameof(operationResult));
                result.IsCompleted = true;
            }
            catch(Exception ex)
            {
                result.Message = _builder.Build(ex.Message, nameof(EFUserRepository), nameof(AddUser));
                result.IsCompleted = false;
            }
            return result;
        }

        

        public async Task<Result<User>> GetUserByUserNameAndPassword(string userName, string password)
        {
            var result = new Result<User>();
            try
            {
                var currentUser = await _context.Users.FirstOrDefaultAsync(
                    u=>u.UserName == userName &&
                    u.Password == password
                    );
                if (currentUser == null)
                    throw new ArgumentNullException(nameof(currentUser));
                result.Data = currentUser;
                result.IsCompleted = true;
            }
            catch(Exception ex)
            {
                result.Message = _builder.Build(ex.Message, nameof(EFUserRepository), nameof(GetUserByUserNameAndPassword)); ;
                result.IsCompleted = false;
            }
            return result;
        }

        public async Task<Result> UpdateMoneyAmount(Guid userId, decimal money)
        {
            var result = new Result();
            try
            {
                var currentUser = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
                currentUser.UpdateAmount(money);
                _context.Update(currentUser);
                await _context.SaveChangesAsync();
                result.IsCompleted = true;
            }
            catch(Exception ex)
            {
                result.Message = _builder.Build(ex.Message, nameof(EFUserRepository), nameof(UpdateMoneyAmount)); ;
                result.IsCompleted = false;
            }
            return result;
        }

        public async Task<Result> UpdateUserName(Guid userId, string userName)
        {
            var result = new Result();
            try
            {
                var currentUser = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
                currentUser.UpdateUserName(userName);
                _context.Update(currentUser);
                await _context.SaveChangesAsync();
                result.IsCompleted = true;
            }
            catch (Exception ex)
            {
                result.Message = _builder.Build(ex.Message, nameof(EFUserRepository), nameof(UpdateUserName)); ;
                result.IsCompleted = false;
            }
            return result;
        }

        public async Task<Result> UpdateUserPassword(Guid userId, string password)
        {
            var result = new Result();
            try
            {
                var currentUser = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
                currentUser.UpdatePassword(password);
                _context.Update(currentUser);
                await _context.SaveChangesAsync();
                result.IsCompleted = true;
            }
            catch (Exception ex)
            {
                result.Message = _builder.Build(ex.Message, nameof(EFUserRepository), nameof(UpdateUserPassword));
                result.IsCompleted = false;
            }
            return result;
        }
    }
}
