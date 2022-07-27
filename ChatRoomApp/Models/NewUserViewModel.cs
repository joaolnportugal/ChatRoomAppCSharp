﻿using ChatRoomApp.Data.Models.Shared;
using System.ComponentModel.DataAnnotations;

namespace ChatRoomApp.Web.Models
{
    public record NewUserViewModel
    {
        [Display(Name = "Name", Prompt = "Todo list name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide a name for the todo list")]
        public string? Name { get; set; }
        public List<UserColor> AvailableColors { get; set; }

        public NewUserViewModel()
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