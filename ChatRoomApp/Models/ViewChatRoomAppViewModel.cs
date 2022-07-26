using ChatRoomApp.Data.Models;
using ChatRoomApp.Data.Models.Shared;
using ChatRoomApp.Web.Infrastructure.Extensions;

namespace ChatRoomApp.Web.Models
{
    public record ViewChatRoomAppViewModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public bool isTyping { get; set; }
        public string ColorCssClasses { get; set; }
        public List<MessageInfo> Messages { get; set; }

        public ViewChatRoomAppViewModel(User user)
        {
            Id = user.Id;
            UserName = user.UserName;
            isTyping = user.isTyping;
            ColorCssClasses = user.UserColor.GetCssClasses();
            Messages = user.Messages.Select(t => new MessageInfo(t)).ToList();
        }

    }

    public class MessageInfo
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public User UserName { get; set; }
        public Color ColorCssClasses { get; set; }


        public MessageInfo(Messages messages)
        {
            Id=messages.Id;
            Message = messages.Message;
            UserName = messages.UserName;
            ColorCssClasses = messages.UserColor;
        }
    }
}
