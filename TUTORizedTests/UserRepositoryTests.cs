
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TUTORized.Models;
using TUTORized.Repository;
using TUTORized.Repository.Abstract;


namespace TUTORizedTests
{
    [TestClass]
    public class UserRepositoryTests : BaseTest
    {

        private readonly IUserRepository _userRepository;

        public UserRepositoryTests()
        {
            _userRepository = new UserRepository(_connection);
        }

        [TestMethod]
        public async Task UserProfileCreateAsync_ShouldPopulateDatabaseWithUserAndReturnThatUser()
        {
            //ARRANGE
            var user = new User("UserRepositoryTest@test.com", "userRepositoryTestPassword", "userRepositoryTestFirstName",
                "userRepositoryTestLastName", "userRepositoryTestRole");

            //ACT
            User retrievedUser = await _userRepository.UserProfileCreateAsync(user);
            
            //ASSERT
            Assert.Equals(user, retrievedUser);
        }

        [TestMethod]
        public async Task GetUserByEmailAsync_ShouldReturnUser()
        {
            //ARRANGE
            string email = "test@test.com";
            string userId = "280A191D-9783-41AE-BE5E-31C33703D459";

            //ACT
            User user = await _userRepository.GetUserByEmailAsync(email);

            //ASSERT
            Assert.AreEqual(userId, user.Id);
        }

        [TestMethod]
        public async Task GetUserByIdAsync_ShouldReturnUser()
        {
            //ARRANGE
            string email = "test@test.com";
            string userId = "280A191D-9783-41AE-BE5E-31C33703D459";

            //ACT
            User user = await _userRepository.GetUserByIdAsync(userId);

            //ASSERT
            Assert.AreEqual(email, user.Email);
        }

        [TestMethod]
        public async Task UserProfileUpdateAsync_ShouldUpdateDatabaseWithNewUserInfoAndReturnThatUser()
        {
            //ARRANGE
            var email = "UserRepositoryTest@test.com";
            var changedEmail = "ChangedEmail@test.com";
            var user = await _userRepository.GetUserByEmailAsync(email);
            user.Email = changedEmail;
                    
            //ACT
            User retrievedUser = await _userRepository.UserProfileUpdateAsync(user);

            //ASSERT
            Assert.Equals(retrievedUser.Email, changedEmail);
        }

        [TestMethod]
        public async Task UserProfileDeleteAsync_ShouldDeleteUserFromDatabase()
        {
            //ARRANGE
            var email = "ChangedEmail@test.com";
            var user = await _userRepository.GetUserByEmailAsync(email);

            //ACT
            await _userRepository.UserProfileDeleteByEmailAsync(user.Email);

            //ASSERT
            Assert.Equals(1, 1); // ???????????????????????????????NEED TO UPDATE??????????????
        }
    }
}
