using ChatRoomApp.Business.Services;
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

            //VERIFICAR PORQUE O MODELO VEM INVÁLIDO

            _chatRoomService.SendMessage(model.Id, model.Message, model.UserColor, model.UserName);

            return View("View",model);
        }

        public IActionResult View(User user)
        {
            if (user.Id == null)
            {
                return RedirectToAction("Index");
            }

            //var chatRoom
            //    = _chatRoomService.GetById(id.Value);
            //if (chatRoom is null)
            //{
            //    return RedirectToAction("Index");
            //}

            var model = new ViewChatRoomAppViewModel(user);

            return View(model);
        }

       
        public IActionResult LogOut([FromForm] ViewChatRoomAppViewModel model) //(int userId)
        {
            var user = _chatRoomService.GetById(model.Id, true);
            _chatRoomService.LogOut(user.Id);

            return RedirectToAction("Index");
        }
    }
}
