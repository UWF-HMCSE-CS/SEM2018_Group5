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
File Name: ChatRepository.cs 
    This class acts acts as an intermediary between the 
    BaseRepository and the logic related to the User in 
    order to relay CRUD operations with the DataBase.
*/

namespace TUTORized.Repository
{
    public class ChatAsStudentRepository : BaseRepository, IChatAsStudentRepository
    {
        public ChatAsStudentRepository(string connection) : base(connection)
        {

        }


        public async Task<Message> CreateMessage(Message message)
        {
            //Initializes Parameters for Stored Procedure
            var parameters = new DynamicParameters();

            //Adds to Parameters
            parameters.Add("UserId", loggedInUser.Id);
            parameters.Add("SendToId", message.SendToId);
            parameters.Add("MessageBody", message.MessageBody);
            parameters.Add("StudentFirstName", loggedInUser.FirstName);
            parameters.Add("StudentLastName", loggedInUser.LastName);

            var result = await FirstJsonResultAsync<Message>("createMessageAsStudent", parameters);
            return result;
        }




    }
}
