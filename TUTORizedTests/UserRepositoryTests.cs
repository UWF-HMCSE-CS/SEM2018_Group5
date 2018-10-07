
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
        public async Task GetUserByEmail_ShouldReturnUser()
        {
            //ARRANGE
            string email = "test@test.com";
            string userId = "280A191D-9783-41AE-BE5E-31C33703D459";

            //ACT
            User user = await _userRepository.GetUserByEmail(email);

            //ASSERT
            Assert.AreEqual(userId, user.Id);
        }
    }
}
