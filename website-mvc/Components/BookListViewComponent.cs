using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace website_mvc.Components
{
    public class BookListViewComponent : ViewComponent
    {
        List<string> books;
        public BookListViewComponent()
        {
            books = new List<string>
            {
                "C# 8.0 Pocket Reference: Instant Help for C# 8.0 Programmers",
                "Pro C# 7: With .NET and .NET Core",
                "Agile Principles, Patterns, and Practices in C#",
                "Concurrency in C# Cookbook: Asynchronous, Parallel, and Multithreaded Programming"
            };
        }
        public IViewComponentResult Invoke()
        {
            return View(books);
        }
    }
}