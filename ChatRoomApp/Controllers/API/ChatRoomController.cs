using ChatRoomApp.Business.Services;
using ChatRoomApp.Data.Models.Shared;
using ChatRoomApp.Web.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace ChatRoomApp.Web.Controllers.API
{

    [Route("api/[controller]")]
    [ApiController]
    public class ChatRoomController : Controller
    {
        private readonly IChatRoomService _chatRoomService;

        public ChatRoomController(IChatRoomService chatRoomService)
        {
            _chatRoomService = chatRoomService;
        }

        [Route("messages")]
        [HttpPost]
        public void SendMessage([FromQuery] int userid, [FromBody] SendMessageDto data)
        {
            _chatRoomService.SendMessage(userid, data.Message, data.UserColor, data.UserName);
            
        }
        // fazer metodo novo que me vai buscar as mensagens todas s´o [route] depois meto o path deste método e depois dá return da partial

        [Route("getPartialMessages")]       
        public IActionResult GetMessages(int userId, bool isTyping)
        {
            if ( isTyping == true)
            {
                _chatRoomService.IsTyping(userId);
            }
            if (isTyping == false)
            {
                _chatRoomService.IsNotTyping(userId);
            }

            var user = _chatRoomService.GetById(userId);
            var messages = _chatRoomService.GetMessages();



            return PartialView("Partials/Partial", messages);
        }
    }
}
