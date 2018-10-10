using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TUTORized.Repository.Abstract;
using Dapper;
using TUTORized.Models;

/**
TUTORized is a web application designed for use in 
schools. Students can coordinate with Tutors to set 
up tutoring sessions. Students and Tutors are also 
able to message each other, as well as share resources
with each other.
@author Timothy McWatters
@author Keenal Shah
@author Wesley Easton
@author Wenwen Xu
@version 1.0
CEN4053    "TUTORized" SEM- Group 5's class project
File Name: UserRepository.cs 
    This class acts acts as an intermediary between the 
    BaseRepository and the logic related to the User in 
    order to relay CRUD operations with the DataBase.
*/

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
        public async Task<User> UserProfileCreateAsync(User user)
        {
            //Initializes Parameters for Stored Procedure
            var parameters = new DynamicParameters();

            //Adds to Parameters
            parameters.Add("Email", user.Email);
            parameters.Add("Password", user.Password);
            parameters.Add("FirstName", user.FirstName);
            parameters.Add("LastName", user.LastName);
            parameters.Add("Role", user.Role);

            var result = await FirstJsonResultAsync<User>("createUser", parameters);
            return result;
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

            return await FirstJsonResultAsync<User>("readUserByEmail", parameters);
        }

        /// <summary>
        /// Retrieves a User from the database by their Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<User> GetUserByIdAsync(string id)
        {
            //Initializes Parameters for Stored Procedure
            var parameters = new DynamicParameters();

            //Adds to Parameters
            parameters.Add("Id", id);

            return await FirstJsonResultAsync<User>("readUserById", parameters);
        }

        /// <summary>
        ///  Updates a User from the database by passing in their updated User object
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<User> UserProfileUpdateAsync(User user)
        {
            //Initializes Parameters for Stored Procedure
            var parameters = new DynamicParameters();

            //Adds to Parameters
            parameters.Add("Id", user.Id);
            parameters.Add("Email", user.Email);
            parameters.Add("FirstName", user.FirstName);
            parameters.Add("LastName", user.LastName);
            parameters.Add("Role", user.Role);

            return await FirstJsonResultAsync<User>("updateUserProfileById", parameters);
        }

        /// <summary>
        /// Deletes a User from the Database
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task UserProfileDeleteByEmailAsync(string email)
        {
            //Initializes Parameters for Stored Procedure
            var parameters = new DynamicParameters();

            //Adds to Parameters
            parameters.Add("Email", email);

            await ExecuteAsync("deleteUserByEmail", parameters);
        }

        /// <summary>
        /// matches the user email and password so the user can successfully log in
        /// </summary>
        /// <typeparam name="User"></typeparam>
        /// <param name=""></param>
        /// <param name=""></param>
        /// <returns></returns>
        public async Task UserLoginAsync(string email, string password)
        {
            var user = new User(email, password);

            //Initializes Parameters for Stored Procedure
            var parameters = new DynamicParameters();
            
            //Check if the email given in the paramter matches the email in db
            if (email.Equals(user.Email))
            {
                //If the email is registered, check for the password
                if (password.Equals(user.Password))
                {
                    //If the email and password matches, then allow them to log in
                    //Not sure how to allow them to go to the next step so I'm just returning the user info here
                    await FirstJsonResultAsync<User>("readUserByEmail", parameters);
                }

                else 
                {
                    //Tell the user their password is incorrect
                    //For now, I'm just going to throw this message to the console
                    Console.WriteLine("Your password is incorrect, try again.");
                }

            }

            //If the email is not registered, tell them it's not registered and to register before you sign in 
            if (email != user.Email)
            {
                //Tell the user that their email does not exist and to register before they can sign in
                Console.WriteLine("Your email does not exist, register your account before signing in");
            }
    

            
        }
    }
}
