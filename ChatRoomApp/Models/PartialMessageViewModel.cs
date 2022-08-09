using ChatRoomApp.Data.Models;
using ChatRoomApp.Data.Models.Shared;
using ChatRoomApp.Web.Infrastructure.Extensions;

namespace ChatRoomApp.Web.Models
{
    public class PartialMessageViewModel
    {

        public List<MessageInfo> Messages { get; set; } = new List<MessageInfo>();

        public PartialMessageViewModel(IEnumerable<Messages> messageList)
        {
            Messages = messageList.Select(t => new MessageInfo(t)).ToList();
        }


    }

}
