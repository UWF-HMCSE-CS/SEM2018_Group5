﻿using System;
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

        /// <summary>
        /// Creates a database entry of a User object; used in User Registration
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task UserProfileCreateAsync(User user)
        {
            //Initializes Parameters for Stored Procedure
            var parameters = new DynamicParameters();

            //Adds to Parameters
            parameters.Add("Email", user.Email);
            parameters.Add("Password", user.Password);
            parameters.Add("FirstName", user.FirstName);
            parameters.Add("LastName", user.LastName);
            parameters.Add("Role", user.Role);

            await ExecuteAsync("createUser", parameters);
        }

        /// <summary>
        /// Retrieves a User from the database by their email address
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public async Task<User> GetUserByEmailAsync(string email)
        {
            //Initializes Parameters for Stored Procedure
            var parameters = new DynamicParameters();

            //Adds to Parameters
            parameters.Add("Email", email);

            return await FirstJsonResultAsync<User>("getUserByEmail", parameters);
        }

        /// <summary>
        /// Retrieves a User from the database by their Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<User> GetUserByIdAsync(string Id)
        {
            //Initializes Parameters for Stored Procedure
            var parameters = new DynamicParameters();

            //Adds to Parameters
            parameters.Add("Id", Id);

            return await FirstJsonResultAsync<User>("getUserById", parameters);
        }

        /// <summary>
        ///  Updates a User from the database by passing in their updated User object
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task UserProfileUpdateAsync(User user)
        {
            //Initializes Parameters for Stored Procedure
            var parameters = new DynamicParameters();

            //Adds to Parameters
            parameters.Add("Id", user.Id);
            parameters.Add("Email", user.Email);
            parameters.Add("Password", user.Password);
            parameters.Add("FirstName", user.FirstName);
            parameters.Add("LastName", user.LastName);
            parameters.Add("Role", user.Role);

            await ExecuteAsync("UserProfileUpdate", parameters);
        }

        /// <summary>
        /// Deletes a User from the Database
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task UserProfileDeleteAsync(string Id)
        {
            //Initializes Parameters for Stored Procedure
            var parameters = new DynamicParameters();

            //Adds to Parameters
            parameters.Add("Id", Id);

            await ExecuteAsync("UserDelete", parameters);
        }
    }
}
