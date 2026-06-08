using SignalRChat.Web.Data;
using Microsoft.AspNetCore.Mvc;

namespace SignalRChat.Web.Controllers
{
    public class ChatController : Controller
    {
        public ApplicationDbContext dbContext { get; }
        public ChatController(ApplicationDbContext _context)
        {
            dbContext = _context;
        }


        public IActionResult Index()
        {
            var viewModel = new ViewModels.ChatIndexViewModel
            {
                Rooms = dbContext.Rooms.ToList(),
                Messages = dbContext.ChatMessages.OrderByDescending(m => m.SentAt).ToList(),
                Users = dbContext.Users.ToList()
            };

            return View(viewModel);
        }
    }
}

