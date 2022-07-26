using ChatRoomApp.Data.Models;
using ChatRoomApp.Data.Models.GenericRepo;
using ChatRoomApp.Data.Models.Shared;
using Microsoft.EntityFrameworkCore;

namespace ChatRoomApp.Business.Services
{
    public interface IChatRoomService
    {
        IEnumerable<User> GetUsers();
        void CreateUser(User user);
        User GetById (int id, bool trackEntity = false);
        void LogOff (User user);
        void SendMessage (int userId, string message, Color userColor);
        
    }

    public class ChatRoomService : IChatRoomService
    {
        private readonly IGenericRepository<User> _userRepo;
        private readonly IGenericRepository<Messages> _messagesRepo;


        public ChatRoomService(IGenericRepository<User> userRepo, IGenericRepository<Messages> messagesRepo)
        {
            _userRepo = userRepo;
            _messagesRepo = messagesRepo;
        }

        public void CreateUser(User user)
        {
            _userRepo.Add(user);
            _userRepo.Save();
        }

        public User GetById(int id, bool trackEntity)
        {
            var query = _userRepo.PrepareQuery();

            if (!trackEntity)
            {
                query = query.AsNoTracking();
            }

            return query
                .Include(x => x.Messages)
                .SingleOrDefault(x => x.Id == id);
        }

        public IEnumerable<User> GetUsers() =>
            _userRepo.PrepareQuery()
            .AsNoTracking()
            .Include(x => x.Messages)
            .ToList();

        public void LogOff(User user)
        {
            throw new NotImplementedException();
        }

        public void SendMessage(int userId, string message, Color userColor)
        {
            var user = _userRepo.PrepareQuery()
                .Include(x => x.Messages)
                .SingleOrDefault(x => x.Id == userId);

            if (user is not null)
            {
                var _message = new Messages()
                {
                    UserColor = userColor,
                    Message = message
                };
                user.Messages.Add(_message);
                _userRepo.Save();
            }
        }
    }
}