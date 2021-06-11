using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using website_mvc.Dto;
using website_mvc.Entities;
using website_mvc.Services.Abstractions;

namespace website_mvc.Components
{
    public class BookListViewComponent : ViewComponent
    {
        private readonly IBookService _bookService;
        
        public BookListViewComponent(IBookService bookService)
        {
            _bookService = bookService;
        }
        
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var books = await _bookService.GetAll();
            return View(books);
        }
    }
}