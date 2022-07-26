using ChatRoomApp.Data.Models.GenericRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatRoomApp.Data.Models
{
    internal class UnitOfWork : IUnitOfWork
    {
        private ChatRoomAppDbContext _context;
        public IGenericRepository<User> _user;
        public IGenericRepository<Messages> _messages;


        public UnitOfWork(ChatRoomAppDbContext dbContext)
        {
            _context = dbContext;
        }


        public IGenericRepository<User> TodoListRepo
        {
            get
            {

                if (this._user == null)
                {
                    this._user = new GenericRepository<User>(_context);
                }
                return _user;
            }
        }

        public IGenericRepository<Messages> MessagesRepo
        {
            get
            {
                if (this._messages == null)
                {
                    this._messages = new GenericRepository<Messages>(_context);

                }
                return _messages;
            }

        }

        public IGenericRepository<User> UserRepo => throw new NotImplementedException();

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
