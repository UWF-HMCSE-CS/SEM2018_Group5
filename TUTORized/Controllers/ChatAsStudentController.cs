using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TUTORized.Models;
using TUTORized.Services.Abstract;

namespace TUTORized.Controllers
{
    [Route("api/chatAsStudent")]
    public class ChatAsStudentController : Controller
    {
        private readonly IChatAsStudentService _chatAsStudentService;

        public ChatAsStudentController(IChatAsStudentService chatAsStudentService)
        {
            _chatAsStudentService = chatAsStudentService;
        }

        [HttpPost("createMessage")]
        public async Task<IActionResult> CreateStudentMessage([FromBody] Message message)
        {
            return Ok(await _chatAsStudentService.CreateMessage(message));
        }



        /* 
        [HttpGet("getListOfMessages")]
        [ProducesResponseType(typeof(IList<Message>), 200)]
        public async Task<IActionResult> GetListOfUserMessages()
        {
            var listOfMessages = await _chatService.GetEntireUserMessageListAsync();
            var test = listOfMessages;
            return Ok(test);
        }

        */
    }

}
