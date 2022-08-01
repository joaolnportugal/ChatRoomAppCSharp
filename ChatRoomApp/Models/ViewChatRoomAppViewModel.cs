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

        public bool isLoggedIn { get; set; }

        public Color UserColor { get; set; } 
        public string ColorCssClasses { get; set; }

        public string Message { get; set; } 
        public List<MessageInfo> Messages { get; set; } = new List<MessageInfo>();
        public List<UserInfo> Users { get; set; } = new List<UserInfo>();

        public ViewChatRoomAppViewModel()
        {

        }

        public ViewChatRoomAppViewModel(User user)
        {
            Id = user.Id;
            UserName = user.UserName;
            isTyping = user.IsTyping;
            isLoggedIn = user.IsLoggedIn;
            ColorCssClasses = user.UserColor.GetCssClasses();
            Messages = user.Messages?.Select(t => new MessageInfo(t)).ToList();
        }

    }


    public class UserInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Color ColorCssClasses { get; set; }
        public bool isTyping { get; set; }
        public ICollection<Messages> Messages { get; set; }
        public bool isLoggedIn { get; set; }


        public UserInfo(User user)
        {
            Id = user.Id;
            Name = user.UserName;
            ColorCssClasses = user.UserColor;
            Messages = user.Messages;
            isLoggedIn = user.IsLoggedIn;
        }

    }

    public class MessageInfo
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public string UserName { get; set; }
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
