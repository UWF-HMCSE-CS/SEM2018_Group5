using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using TUTORized;

namespace TUTORizedTests
{
    public class UserRepositoryTests
    {



        [Fact]
        public void TestAbleToCreateUserProfile()
        {
            //ARRANGE
            var sut = new UserRepository();
            var user = new User("UserRepositoryTest@test.com", "userRepositoryTestPassword", "userRepositoryTestFirstName",
                "userRepositoryTestLastName", "userRepositoryTestRole");

            //ACT
            sut.UserProfileCreateAsync(user);
            User retrievedUser = GetUserByEmailAsync("UserRepositoryTest@test.com");

            //ASSERT
            Assert.Equals(user, retrievedUser);
        }
    }
}


Task UserProfileCreateAsync(User user);

Task<User> GetUserByEmailAsync(string email);

Task<User> GetUserByIdAsync(string Id);

Task UserProfileUpdateAsync(User user);

Task UserProfileDeleteAsync(string Id);