using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using website_mvc.Dto;
using website_mvc.Services.Abstractions;

namespace website_mvc.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _bookService;
        
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }
        
        public async Task<IActionResult> GetById(string id)
        {
            var book = await _bookService.GetById(id);
            return View("Index", book);
        }
    }
}