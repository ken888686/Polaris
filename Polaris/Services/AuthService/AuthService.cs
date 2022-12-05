using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Polaris.Repositories;

namespace Polaris.Services.AuthService
{
    public class AuthService : IAuthService
    {
        public readonly IAuthRepository _authRepository;
        public AuthService(IAuthRepository authRepository)
        {
            this._authRepository = authRepository;
        }
        public async Task<ServiceResponse<int>> RegisterAsync(User user, string password)
        {
            return await this._authRepository.Register(user, password);
        }
        public async Task<ServiceResponse<string>> LoginAsync(string username, string password)
        {
            return await this._authRepository.Login(username, password);
        }
    }
}
