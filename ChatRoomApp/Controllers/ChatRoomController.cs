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
                UserColor = (Color)model.SelectedColor
            };
            _chatRoomService.CreateUser(user);


            return RedirectToAction("View");
        }

        public IActionResult View(int? id)
        {
            if (id is null)
            {
                return RedirectToAction("Index");
            }

            var chatRoom
                = _chatRoomService.GetById(id.Value);
            if (chatRoom is null)
            {
                return RedirectToAction("Index");
            }

            var model = new ViewChatRoomAppViewModel(chatRoom);
            return View(model);
        }
    }
}
