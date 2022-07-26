using ChatRoomApp.Data.Models.Shared;

namespace ChatRoomApp.Web.Infrastructure.Extensions
{
    public static class ColorExtensions
    {
        public static string GetCssClasses(this Color color)
            => color switch
            {
                Color.DarkBlue => "bg-primary text-white",
                Color.DarkGray => "bg-secondary text-white",
                Color.Green => "bg-success text-white",
                Color.Red => "bg-danger text-white",
                Color.Yellow => "bg-warning text-dark",
                Color.LightBlue => "bg-info text-dark",
                Color.Black => "bg-dark text-white",
                Color.White => "bg-white text-dark",
                _ => "bg-primary text-white",
            };
    }
}
