using Microsoft.AspNetCore.Mvc;

namespace website_mvc.Controllers
{
    public class BookController : Controller
    {
        // GET
        public IActionResult Index(int id)
        {
            return View(id);
        }
    }
}