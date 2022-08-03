using ChatRoomApp.Data.Models;
using ChatRoomApp.Data.Models.Shared;
using System.ComponentModel.DataAnnotations;

namespace ChatRoomApp.Web.Models
{
    public record LogInViewModel
    {
        [Display(Name = "Name", Prompt = "Enter Username")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please insert a valid Username")]
        public string? Name { get; set; }
        public List<User> UserList { get; set; } = new List<User>();

        [Range(10, 80,
        ErrorMessage = "Please choose a color")]
        public int SelectedColor { get; set; }


        //[Required( ErrorMessage = "Please choose a color")]
        public List<UserColor> AvailableColors { get; set; }

        public bool isLoggedIn { get; set; } = true;


        public LogInViewModel()
        {
            AvailableColors = Enum.GetValues<Color>().Select(c => new UserColor(c)).ToList();
        }

        public record UserColor
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string CssClassName { get; set; }

            public UserColor(Color color)
            {
                Id = (int)color;
                Name = color.ToString();
                CssClassName = color switch
                {
                    Color.DarkBlue => "btn-outline-primary",
                    Color.DarkGray => "btn-outline-secondary",
                    Color.Green => "btn-outline-success",
                    Color.Red => "btn-outline-danger",
                    Color.Yellow => "btn-outline-warning",
                    Color.LightBlue => "btn-outline-info",
                    Color.Black => "btn-outline-dark",
                    Color.White => "btn-outline-white",
                    _ => "btn-outline-primary"
                };
            }
        }
    }
}
