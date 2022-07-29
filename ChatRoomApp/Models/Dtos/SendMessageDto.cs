

using ChatRoomApp.Data.Models.Shared;

namespace ChatRoomApp.Web.Models.Dtos
{
    public class SendMessageDto
    {
        public string Message { get; set; }
        public Color UserColor { get; set; }
    }
}
