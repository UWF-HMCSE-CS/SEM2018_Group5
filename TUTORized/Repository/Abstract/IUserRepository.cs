using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TUTORized.Models;

namespace TUTORized.Repository.Abstract
{
    public interface IUserRepository
    {
        Task UserProfileCreateAsync(User user);

        Task<User> GetUserByEmailAsync(string email);

        Task<User> GetUserByIdAsync(string Id);

        Task UserProfileUpdateAsync(User user);

        Task UserProfileDeleteAsync(string Id);
    }
}
