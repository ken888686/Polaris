using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Polaris.Repositories
{
    public interface IAuthRepository
    {
        Task<ServiceResponse<int>> Register(User user, string password);
        Task<ServiceResponse<int>> Login(string username, string password);
        Task<bool> UserExists(string username);
    }
}
