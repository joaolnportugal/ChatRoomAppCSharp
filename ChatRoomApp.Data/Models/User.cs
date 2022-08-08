using ChatRoomApp.Data.Models.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatRoomApp.Data.Models
{
    public class User : EntityBase
    {
        public string UserName { get; set; }
        [Required]
        public Color UserColor { get; set; }
        public bool IsTyping { get; set; } = false;
        public bool IsLoggedIn { get; set; } 


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
                .HasDefaultValue(Color.Yellow)
                .IsRequired();

            builder.Property(x => x.IsLoggedIn)
                .HasDefaultValue(true)
                .IsRequired();
            
            builder.Property(x => x.IsTyping)
                .HasDefaultValue(true)
                .IsRequired();
        }
    }
}
