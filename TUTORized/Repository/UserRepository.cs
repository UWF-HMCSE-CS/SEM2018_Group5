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
            parameters.Add("User", user);

            await ExecuteAsync("UserProfile_Create", parameters);
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



        /// FINISH CRUD HERE
        /// ////////////////////////////////////
      





        public async Task<User> AccountInfoGetAsync(User email)
        {
            return new User
            {
                Email = user.email,
                Password = user.password,
                FirstName = user.firstName,
                LastName = user.lastName,
                Role = user.role,
            };
        }

        public async Task<string> AccountProfileGetAsync(User user)
        {
            return await AccountProfileGetAsync(user.Id).ConfigureAwait(false);
        }

        public async Task<string> AccountProfileGetAsync(string userId)
        {
            return await JsonResultAsync(nameof(this.AccountProfileGetAsync), new { AspNetUserId = userId }).ConfigureAwait(false);
        }

        public async Task<string> AccountProfileUpsertAsync(string userId, UserProfile profile)
        {
            return await JsonResultAsync("UpdateUserAccountProfile", new { AspNetUserId = userId, Details = profile }).ConfigureAwait(false);
        }

        public async Task<User> FindByEmailAsync(string email)
        {
            return (await QueryAsync<User>("identity_GetUserByEmail", Parameters(new { Email = email })).ConfigureAwait(false))
                .FirstOrDefault();
        }

        public async Task<User> FindByIdAsync(string userId)
        {
            return (await QueryAsync<User>("identity_GetUserById", new { UserId = userId }).ConfigureAwait(false))
                .FirstOrDefault();
        }

        public async Task<User> GetAsync(User user)
        {
            return await FindByIdAsync(user.Id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<User>> ListInRoleAsync(string roleName)
        {
            return await QueryAsync<User>(
                        "identity_GetUsersInRole",
                        Parameters(new { RoleName = roleName })).ConfigureAwait(false);
        }

        public Task<UserProfile> ProfileGetAsync(string userId)
        {
            return JsonFirstAsync<UserProfile>("sp_GetUserProfile", new { user_id = userId });
        }

        public async Task ProfileUpdateAsync(string userId, UserProfile userProfile)
        {
            await ExecuteAsync(
                "UserProfile_Update",
                new
                {
                    Id = userId,
                    PhoneNumber = userProfile.Phone,
                    userProfile.FirstName,
                    userProfile.LastName,
                    DateOfBirth = userProfile.DoB,
                    JsonData = JsonParam(new { address = userProfile.Address })
                }).ConfigureAwait(false);
        }

        public async Task<ApplicationRole> RoleFindByNameAsync(string roleName)
        {
            return (await RoleListAsync().ConfigureAwait(false)).FirstOrDefault(role => role.Name == roleName);
        }

    }
}
