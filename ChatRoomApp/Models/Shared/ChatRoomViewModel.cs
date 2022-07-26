using ChatRoomApp.Data.Models.Shared;
using System.ComponentModel.DataAnnotations;

namespace ChatRoomApp.Web.Models.Shared
{
    public class ChatRoomViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Name", Prompt = "UserName")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide User Name")]
        public string Name { get; set; }

        //public int SelectedColor { get; set; }
        public List<UserColor> AvailableColors { get; set; }

        public ChatRoomViewModel()
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

