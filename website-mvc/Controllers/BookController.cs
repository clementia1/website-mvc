﻿using System.Threading.Tasks;
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

        public async Task<IActionResult> Delete(string id)
        {
            await _bookService.Delete(id);
            var books = await _bookService.GetAll();
            return View("../Home/Admin", books);
        }

        public async Task<IActionResult> Edit(string id)
        {
            var book = await _bookService.GetById(id);
            return View("EditBook", book);
        }

        public async Task<IActionResult> Update([FromBody] BookDto bookDto)
        {
            await _bookService.Update(bookDto);
            var books = await _bookService.GetAll();
            return View("../Home/Admin", books); 
        }

        public IActionResult AddBook()
        {
            return View();
        }

        public async Task<IActionResult> Create([FromBody] BookDto bookDto)
        {
            await _bookService.Create(bookDto);
            var books = await _bookService.GetAll();
            return View("../Home/Admin", books); 
        }
    }
}