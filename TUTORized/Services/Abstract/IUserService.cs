using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TUTORized.Models;

namespace TUTORized.Services.Abstract
{
    public interface IUserService
    {
        User CreateUserObject();


        User CreateUserObject(string email, string password, string firstName, string lastName, string role);


        User CreateUserObject(string id, string email, string password, string firstName, string lastName, string role);


        void RegisterUser(string email, string password, string firstName, string lastName, string role);

    }
}
