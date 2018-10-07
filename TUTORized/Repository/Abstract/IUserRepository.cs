using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TUTORized.Models;

namespace TUTORized.Repository.Abstract
{
    public interface IUserRepository
    {
        Task<User> ReadUserByEmail(string email);
    }
}
