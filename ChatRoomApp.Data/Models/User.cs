using ChatRoomApp.Data.Models.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatRoomApp.Data.Models
{
    public class User : EntityBase
    {
        public string UserName { get; set; }
        public Color UserColor { get; set; }      
        public ICollection<Messages> Messages { get; set; }
        public bool isTyping { get; set; }
        public bool isLoggedIn { get; set; }

    }


    public class TodoListConfiguration : EntityBaseConfiguration<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            base.Configure(builder);

            builder.ToTable("User");

            builder.Property(x => x.UserName)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(x => x.UserColor)
                .HasDefaultValue(Color.DarkBlue)
                .IsRequired();
            builder.Property(x => x.isLoggedIn)
                .HasDefaultValue(false)
                .IsRequired();
            
        }
    }
}
