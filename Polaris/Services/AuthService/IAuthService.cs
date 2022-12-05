using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Polaris.Services.AuthService
{
    public interface IAuthService
    {
        public Task<ServiceResponse<int>> RegisterAsync(User user, string password);
        public Task<ServiceResponse<string>> LoginAsync(string username, string password);
    }
}
