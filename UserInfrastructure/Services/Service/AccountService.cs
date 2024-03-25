using AutoMapper;
using Common.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Repositories.Interface;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Services.Service
{
    public class AccountService : IAccountService
    {
        public readonly IAccountRepository _accountRepository;
        public readonly AuthHelpers _authHelpers;
        private readonly IMapper _mapper;
        public AccountService(IAccountRepository accountRepository, AuthHelpers authHelpers)
        { 
            _accountRepository = accountRepository;
            _authHelpers = authHelpers;
        }


        public async Task<LoginResponse> AuthenticateAsync(string username, string password)
        {

            var user = await _accountRepository.GetUserAsync(username, password);
            if (user == null)
            {
                var res = new LoginResponse();
                res.Message = "Invalid User";

                return res;
            }
            else
            {
                return _authHelpers.GenerateToken(user);
            }
        }
        public async Task<UserViewModel> GetUserDetailsAsync(string username)
        {
           var res = new UserViewModel();
            var user = await _accountRepository.GetUserAsync(username);
            if (user != null)
            {
                res.Username = user.Username;
                res.UserId = user.UserId;
                res.Email = user.Email;
                res.Role = user.Role;

                return res;
            }
            else
            {
                return null;
            }
        }
        public async Task<List<UserViewModel>> GetAllUserDetailsAsync()
        {       
            var user = await _accountRepository.GetAllUserAsync();
            if (user != null)
            {
                return _mapper.Map<List<UserViewModel>>(user);               
            }
            else
            {
                return null;
            }
        }
    }
}
