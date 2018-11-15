using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TUTORized.Models;
using TUTORized.Repository.Abstract;
using TUTORized.Services.Abstract;

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
File Name: ChatService.cs 
    This class provides the logic for all Tutor actions.
*/

namespace TUTORized.Services
{
    public class ChatAsTutorService : IChatAsTutorService
    {
        private readonly IChatAsTutorRepository _chatAsTutorRepository;

        public ChatAsTutorService(IChatAsTutorRepository chatAsTutorRepository)
        {
            _chatAsTutorRepository = chatAsTutorRepository;
        }

      
        public async Task<Message> CreateMessage(Message message)
        {
            return await _chatAsTutorRepository.CreateMessage(message);
        }

        /* 
        public async Task<IEnumerable<Appointment>> GetEntireUserMessageListAsync()
        {
            return await _chatRepository.GetEntireUserMessageListAsync();
        }
        */
    }
}