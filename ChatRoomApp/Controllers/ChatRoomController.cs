using ChatRoomApp.Business.Services;
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

        public IActionResult View(int? id)
        {
            if (id is null)
            {
                return RedirectToAction("Index");
            }

            var todoList = _chatRoomService.GetById(id.Value);
            if (todoList is null)
            {
                return RedirectToAction("Index");
            }

            var model = new ViewChatRoomAppViewModel(todoList);
            return View(model);
        }
    }
}
