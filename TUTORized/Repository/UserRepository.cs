using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TUTORized.Repository.Abstract;
using Dapper;
using TUTORized.Models;

namespace TUTORized.Repository
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(string connection) : base(connection)
        {

        }

        public async Task<User> ReadUserByEmail(string email)
        {
            //Initializes Parameters for Stored Procedure.
            var parameters = new DynamicParameters();

            //Adds to Parameters
            parameters.Add("Email", email);

            return await FirstJsonResultAsync<User>("readUserByEmail", parameters);
        }
    }
}
