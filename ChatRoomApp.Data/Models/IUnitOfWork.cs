using ChatRoomApp.Data.Models.GenericRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatRoomApp.Data.Models
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<User> UserRepo { get; }
        IGenericRepository<Messages> MessagesRepo { get; }
        

        void Save();
    }
}
