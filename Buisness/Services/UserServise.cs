using AutoMapper;
using Buisness.Extentions;
using Buisness.Logging;
using Buisness.ViewModels;
using Domain.Entities;
using DomainAccess.Interfaces;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Buisness.Services
{
    public class UserServise
    {
        private readonly IUserRepository _userRepos;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public UserServise(IUserRepository userRepos,IMapper mapper,ILogger logger)
        {
            _userRepos = userRepos;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<UserViewModel> AddUser(UserViewModel userModel)
        {
            userModel.Password = userModel.Password.HashPassword();
            var user = _mapper.Map<User>(userModel);
            
            var result = await _userRepos.AddUser(user);
            if (!result.IsCompleted)
                await _logger.LoggerAsync(result.Message);

            var model = _mapper.Map<UserViewModel>(user);
            return model;
        }

        public async Task UpdateUserName(Guid userId,string userName)
        {
            var res = await _userRepos.UpdateUserName(userId, userName);
            if (!res.IsCompleted)
                await _logger.LoggerAsync(res.Message);

        }
        public async Task UpdateUserPassword(Guid userId,string password)
        {
            var res = await _userRepos.UpdateUserPassword(userId, password.HashPassword());
            if (!res.IsCompleted)
                await _logger.LoggerAsync(res.Message);

        }
        public async Task UpdateUserAmount(Guid userId,decimal money)
        {
            var result = await _userRepos.UpdateMoneyAmount(userId, money);
            if (!result.IsCompleted)
                await _logger.LoggerAsync(result.Message);
        }
        public async Task<UserViewModel> GetUser(string userName,string password)
        {
            var result = await _userRepos.GetUserByUserNameAndPassword(userName, password.HashPassword());
            if (!result.IsCompleted)
                await _logger.LoggerAsync(result.Message);
            var model = _mapper.Map<UserViewModel>(result.Data);
            return model;
        }


    }
}
