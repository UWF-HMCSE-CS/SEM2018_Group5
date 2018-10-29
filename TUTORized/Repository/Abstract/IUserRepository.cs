using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
File Name: IUserRepository.cs 
    This is the interface for the UserRepository class.
*/

namespace TUTORized.Repository.Abstract
{
    public interface IUserRepository
    {
        Task<User> UserProfileCreateAsync(User user);

        Task<User> GetUserByEmailAsync(string email);

        Task<User> GetUserByIdAsync(string Id);

        Task<User> UserProfileUpdateAsync(User user);

        Task UserProfileDeleteByEmailAsync(string email);

        Task<User> UserLoginAsync(string userEmail, string userPassword);

        Task<IEnumerable<Appointment>> GetEntireUserAppointmentListAsync();
    }
}
