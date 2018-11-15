using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TUTORized.Models;
using TUTORized.Services.Abstract;

namespace TUTORized.Controllers
{
    [Route("api/chatAsTutor")]
    public class ChatAsTutorController : Controller
    {
        private readonly IChatAsTutorService _chatAsTutorService;

        public ChatAsTutorController(IChatAsTutorService chatAsTutorService)
        {
            _chatAsTutorService = chatAsTutorService;
        }

        [HttpPost("createMessage")]
        public async Task<IActionResult> CreateTutorMessage([FromBody] Message message)
        {
            return Ok(await _chatAsTutorService.CreateMessage(message));
        }

        [HttpGet("getListOfMessages")]
        [ProducesResponseType(typeof(IList<Message>), 200)]
        public async Task<IActionResult> GetListOfUserMessages()
        {
            var listOfMessages = await _chatAsTutorService.GetEntireUserMessagesListAsync();
            var test = listOfMessages;
            return Ok(test);
        }

    }

}
