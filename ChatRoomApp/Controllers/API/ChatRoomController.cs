using ChatRoomApp.Business.Services;
using ChatRoomApp.Data.Models.Shared;
using ChatRoomApp.Web.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace ChatRoomApp.Web.Controllers.API
{

    [Route("api/[controller]")]
    [ApiController]
    public class ChatRoomController : ControllerBase
    {
        private readonly IChatRoomService _chatRoomService;

        public ChatRoomController(IChatRoomService chatRoomService)
        {
            _chatRoomService = chatRoomService;
        }

        [Route("messages")]
        [HttpPost]
        public void SendMessage([FromQuery] int userId, [FromBody] SendMessageDto data, [FromQuery] Color userColor )
        {
            _chatRoomService.SendMessage(userId, data.Message, userColor);
        }
    }
}
