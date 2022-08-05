using ChatRoomApp.Data.Models;
using ChatRoomApp.Data.Models.GenericRepo;
using ChatRoomApp.Data.Models.Shared;
using Microsoft.EntityFrameworkCore;

namespace ChatRoomApp.Business.Services
{
    public interface IChatRoomService
    {
        IEnumerable<User> GetUsers();
        IEnumerable<Messages> GetMessages();

        User CreateOrEditUser(User user);
        User GetById (int id);
        User GetByName (string username, bool trackEntity = false);
        void LogOut (int userId);
        void SendMessage (int userId, string message, Color color, string userName);
        void IsTyping(int userId);
        void IsNotTyping(int userId);




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

        public User CreateOrEditUser(User user)
        {
            //Fazer um get por username
            var _user = GetByName(user.UserName, true);
            
            
            //If que verifica se existe
            if (_user is not null)
            {
                _user.IsLoggedIn = true;
                _user.UserColor = user.UserColor;
                
               

                _userRepo.Save();

                return _user;
            }
           
            else 
            {
                _userRepo.Add(user);
                _userRepo.Save();

                return user;
            }
                
            
        }

        public User GetById(int id)
        {
            return _userRepo.Find(id);
        }

        public User GetByName(string username, bool trackEntity)
        {
            var query = _userRepo.PrepareQuery();

            if (!trackEntity)
            {
                query = query.AsNoTracking();
            }
            return query
                .SingleOrDefault(x => x.UserName == username);
        }

      

        public IEnumerable<Messages> GetMessages() =>

            _messagesRepo.PrepareQuery()
                .AsNoTracking()                
                .ToList();
        public IEnumerable<User> GetUsers() =>
            _userRepo.PrepareQuery()
            .Where(x => x.IsLoggedIn == true)
            .AsNoTracking()
            .ToList();

        public void LogOut(int userId)
        {
            var user = _userRepo.Find(userId);
            user.IsLoggedIn = false;
            _userRepo.Save();
        }

        public void SendMessage(Messages message)
        {
            _messagesRepo.Add(message);
            _messagesRepo.Save();
        }



        public void SendMessage(int userId, string message, Color color, string userName)
        {
            
            var _message = new Messages()
            {
                UserId = userId,
                Message = message,
                UserColor = (Color)color,
                UserName = userName
            };

            SendMessage(_message);
        }

        public void IsTyping(int userId)
        {
            var typing = _userRepo.Find(userId);
            typing.IsTyping = true;
            _userRepo.Save();
        }

        public void IsNotTyping(int userId)
        {
            var typing = _userRepo.Find(userId);
            typing.IsTyping = false;
            _userRepo.Save();
        }
    }
}