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
    public class Messages : EntityBase
    {
        public int UserId { get; set; }
        public Color UserColor { get; set; }
        public string Message { get; set; }
        public User UserName { get; set; }
    }

    public class TodoListTaskConfiguration : EntityBaseConfiguration<Messages>
    {
        public override void Configure(EntityTypeBuilder<Messages> builder)
        {
            base.Configure(builder);

            builder.ToTable("Messages");

            builder.Property(x => x.Message)
                .HasMaxLength(150)
                .IsRequired();


            builder.Property(x => x.UserId)
                .HasDefaultValue(false)
                .IsRequired();

            builder.HasOne(x => x.UserName)
                .WithMany(x => x.Messages)
                .HasForeignKey(x => x.UserId);

            builder.Property(x => x.UserColor)
                .HasMaxLength(150)
                .IsRequired();


        }
    }
}
