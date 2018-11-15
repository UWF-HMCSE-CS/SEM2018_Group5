using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TUTORized.Repository;

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
File Name: Message.cs 
    This class is the User Model. 
*/

namespace TUTORized.Models
{
    public class Message
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("studentId")]
        public string StudentId { get; set; }

        [JsonProperty("tutorId")]
        public string TutorId { get; set; }

        [JsonProperty("sendToId")]
        public string SendToId { get; set; }

        [JsonProperty("messageBody")]
        public DateTime MessageBody { get; set; }

        [JsonProperty("studentFirstName")]
        public string StudentFirstName { get; set; }

        [JsonProperty("studentLastName")]
        public string StudentLastName { get; set; }

        [JsonProperty("tutorFirstName")]
        public string TutorFirstName { get; set; }

        [JsonProperty("tutorLastName")]
        public string TutorLastName { get; set; }



        

       
    }
}
