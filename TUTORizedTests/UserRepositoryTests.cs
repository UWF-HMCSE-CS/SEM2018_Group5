using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TUTORized.Models;
using TUTORized.Repository;
using TUTORized.Repository.Abstract;


namespace TUTORizedTests
{
    [TestClass]
    public class UserRepositoryTests
    {
        private IUserRepository _userRepository;

        [TestInitialize]
        public async Task Setup()
        {
            IConfigurationBuilder _configurationBuilder = new ConfigurationBuilder();
            _configurationBuilder.AddJsonFile("appsettings.Development.json");
            IConfiguration _configuration = _configurationBuilder.Build();

            _userRepository = new UserRepository(_configuration.GetConnectionString("tma"));
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
