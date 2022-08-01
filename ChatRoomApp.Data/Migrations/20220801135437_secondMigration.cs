using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChatRoomApp.Data.Migrations
{
    public partial class secondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "isTyping",
                table: "User",
                newName: "IsTyping");

            migrationBuilder.RenameColumn(
                name: "isLoggedIn",
                table: "User",
                newName: "IsLoggedIn");

            migrationBuilder.AlterColumn<bool>(
                name: "IsLoggedIn",
                table: "User",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Messages",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Messages");

            migrationBuilder.RenameColumn(
                name: "IsTyping",
                table: "User",
                newName: "isTyping");

            migrationBuilder.RenameColumn(
                name: "IsLoggedIn",
                table: "User",
                newName: "isLoggedIn");

            migrationBuilder.AlterColumn<bool>(
                name: "isLoggedIn",
                table: "User",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);
        }
    }
}
