using ChatRoomApp.Data.Models;
using ChatRoomApp.Data.Models.Shared;
using ChatRoomApp.Web.Infrastructure.Extensions;
using System.ComponentModel.DataAnnotations;

namespace ChatRoomApp.Web.Models
{
    public record ViewChatRoomAppViewModel
    {
        public int userId { get; set; }
        public int messageId { get; set; }
        public string UserName { get; set; } 

        public bool isLoggedIn { get; set; }
        public bool isTyping { get; set; } = false;

        public Color UserColor { get; set; } 
        public string ColorCssClasses { get; set; }

        [MaxLength(150)]
        public string Message { get; set; } = string.Empty;
        public List<MessageInfo> Messages { get; set; } = new List<MessageInfo>();
        public List<UserInfo> Users { get; set; } = new List<UserInfo>();

        public UserInfo UserInfo { get; set; } = new UserInfo();
        public PartialMessageViewModel MessageModel { get; set; }
        public PartialUsersViewModel UserModel { get; set; }


        public ViewChatRoomAppViewModel()
        {
            
        }


        public ViewChatRoomAppViewModel(User user, List<User> userList, List<Messages> messageList)
        {
            userId = user.Id;
            UserName = user.UserName; 
            UserColor = user.UserColor; 
            ColorCssClasses = UserColor.ToString();
            isLoggedIn = user.IsLoggedIn;            
            Users = userList.Select(t => new UserInfo(t)).ToList();
            Messages = messageList.Select(t => new MessageInfo(t)).ToList();
            isTyping = user.IsTyping;
            UserModel = new PartialUsersViewModel(userList);
            MessageModel = new PartialMessageViewModel(messageList);
        }


    }


    public class UserInfo
    {
        public int userId { get; set; }
        public string Name { get; set; }
        public string ColorCssClasses { get; set; }
        public bool isTyping { get; set; } = false;
        public ICollection<Messages> Messages { get; set; }
        public bool isLoggedIn { get; set; }


        public UserInfo(User user)
        {
            userId = user.Id;
            Name = user.UserName;
            ColorCssClasses = user.UserColor.GetCssClasses();
            isTyping = user.IsTyping;
            isLoggedIn = user.IsLoggedIn;
        }

        public UserInfo()
        {
        }
    }

    public class MessageInfo
    {
        public int messageId { get; set; }
        public string Message { get; set; }
        public string UserName { get; set; }
        public string ColorCssClasses { get; set; }
        public DateTimeOffset Created { get; set; }


        public MessageInfo(Messages messages)
        {
            messageId=messages.Id;
            Message = messages.Message;
            UserName = messages.UserName;
            ColorCssClasses = messages.UserColor.GetCssClasses();
            Created = messages.Updated;
        }
    }
}
