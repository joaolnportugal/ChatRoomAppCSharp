using ChatRoomApp.Data.Models;
using ChatRoomApp.Data.Models.Shared;


namespace ChatRoomApp.Web.Models
{
    public class ChatChatRoomAppViewModel
    {

        private IEnumerable<User> _users;
        private IEnumerable<Messages> _messages;

        private List<UserInfo> Users { get; set; } = new List<UserInfo>();
        private List<MessagesInfo> Messages { get; set; } = new List<MessagesInfo>();

        public ChatChatRoomAppViewModel(List<User> users ,List<Messages> messages)
        {
            Users = users.Select(t => new UserInfo(t)).ToList();
            Messages = messages.Select(t => new MessagesInfo(t)).ToList();

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
            isLoggedIn = user.isLoggedIn;
            }

    }

    public class MessagesInfo
    {
        public int UserId { get; set; }
        public Color UserColor { get; set; }
        public string Message { get; set; }
        public User UserName { get; set; }

        public MessagesInfo(Messages messages)
        {
            UserId = messages.UserId;
            UserName = messages.UserName;
            UserColor = messages.UserColor;
            Message = messages.Message;
        }

    }
}
