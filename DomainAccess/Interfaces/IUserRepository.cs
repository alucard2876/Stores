using Domain.Entities;
using System;
using System.Threading.Tasks;

namespace DomainAccess.Interfaces
{
    public interface IUserRepository
    {
        Task<Result<User>> GetUserByUserNameAndPassword(string userName, string password);
        Task<Result> AddUser(User user);
        Task<Result> UpdateUserName(Guid userId,string userName);
        Task<Result> UpdateUserPassword(Guid userId, string password);
        Task<Result> UpdateMoneyAmount(Guid userId, decimal money);
    }
}
