﻿using ChatRoomApp.Business.Services;
using ChatRoomApp.Data.Models;
using ChatRoomApp.Data.Models.Shared;
using ChatRoomApp.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace ChatRoomApp.Web.Controllers
{
    public class ChatRoomController : Controller

    {
        private IChatRoomService _chatRoomService;
        private int id;
        

        public ChatRoomController(IChatRoomService chatRoomService)
        {
            _chatRoomService = chatRoomService;         
        }

    


        public IActionResult Index()
        {
            var model = new LogInViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index([FromForm] LogInViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = new User()
            
            {
                UserName = model.Name,
                UserColor = (Color)model.SelectedColor,
                IsLoggedIn = true
            };
            _chatRoomService.CreateOrEditUser(user);

            return RedirectToAction("View", user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SendMessage([FromForm] ViewChatRoomAppViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("View", model);
            }

            

            _chatRoomService.SendMessage(model.messageId, model.Message, model.UserColor, model.UserName);

            return RedirectToAction ("View",model); 
        }

        public IActionResult View(User user, Messages messages)
        {
            if (user.Id == null)
            {
                return RedirectToAction("Index");
            }

            
            var userLists = _chatRoomService.GetUsers();
            var messageLists = _chatRoomService.GetMessages();

            var model = new ViewChatRoomAppViewModel(user, messages, userLists.ToList(), messageLists.ToList());

            return View(model);
        }

       
        public IActionResult LogOut([FromForm] ViewChatRoomAppViewModel model) //(int userId)
        {
            //User user = new User();
            var user = _chatRoomService.GetById(model.userId, true);
            _chatRoomService.LogOut(user.Id);

            return RedirectToAction("Index");
        }
    }
}
