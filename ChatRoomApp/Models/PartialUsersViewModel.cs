using ChatRoomApp.Data.Models;

namespace ChatRoomApp.Web.Models
{
    public class PartialUsersViewModel
    {
        public List<UserInfo> Users { get; set; } = new List<UserInfo>();

        public UserInfo userInfo = new UserInfo();




        public PartialUsersViewModel(IEnumerable<User> userList)
        {
            Users = userList.Select(t => new UserInfo(t)).ToList();
            
        }
    }
}
