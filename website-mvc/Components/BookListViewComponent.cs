using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using website_mvc.Dto;

namespace website_mvc.Components
{
    public class BookListViewComponent : ViewComponent
    {
        List<BookDto> books;
        public BookListViewComponent()
        {
            books = new List<BookDto>
            {
                new BookDto
                {
                    Id = 1, 
                    Title = "Effective C# (Covers C# 6.0), (includes Content Update Program)",
                    Author = "Bill Wagner",
                    Description = "Effective C# is a book written by Bill Wagner. The book helps the programmer to write exceptionally robust and well-performing code. The writer's clear, practical explanations, expert tips, and realistic code examples have made Effective C# indispensable to hundreds of thousands of developers."
                },
                new BookDto
                {
                    Id = 2,
                    Title = "C# 8.0 Pocket Reference: Instant Help for C# 8.0 Programmers",
                    Author = "Joseph Albahari",
                    Description = "C# 8.0 Pocket Reference is a book written by Joseph Albahari. It is an ideal book and quick source of information that helps or as a guide to rapidly speed up if you know Java, C++, or some earlier C# versions. All C# programs and code snippets are available as interactive samples in LINQPad. You create these samples and have results without the need to set up projects in Visual Studio."
                },
                new BookDto
                {
                    Id = 3,
                    Title = "Pro C# 7: With .NET and .NET Core",
                    Author = "Andrew Troelsen and Philip Japikse",
                    Description = "Pro C# 7: With .NET and .NET Core is a book written by Andrew Troelsen and Philip Japikse. The book provides a comprehensive foundation in the C# programming language and the frameworks it lives in. The book covers C# 7.1 and .NET 4.7 features along with dedicated chapters on Microsoft's lightweight, cross-platform framework. The book also includes NET Core 2.0. Coverage and ASP.NET Core, Entity Framework (EF) Core. Communication Foundation (WCF), and ASP.NET MVC."
                },
                new BookDto
                {
                    Id = 4,
                    Title = "Agile Principles, Patterns, and Practices in C#",
                    Author = "Robert C. Martin and Micah Martin",
                    Description = "Agile Principles, Patterns, and Practices in C# is a book written by Robert C. Martin and Micah Martin. This reference book presents a series of case studies that help to illustrate the fundamentals of C# language. Agile development and Agile design, and moves also quickly allow from UML models to real C# code. The beginning chapters teach you the basics of the agile movement, while the later chapters show many proven techniques. The reference includes many source code examples that are also available for download from the authors' Website."
                },
                new BookDto
                {
                    Id = 5,
                    Title = "Concurrency in C# Cookbook: Asynchronous, Parallel, and Multithreaded Programming",
                    Author = "Stephen Cleary",
                    Description = "Concurrency in C# Cookbook is a book written by Stephen Cleary demonstrates parallel processing and asynchronous programming techniques by using libraries and language features in .NET and C# 8.0. This cookbook also shows you how modern tools help you to make the level of abstraction, making concurrency much easier and effective. The book offer ready-to-use code and discussions about how and why solutions work, these recipes help you, to solve numerous C# solutions."
                }
            };
        }
        public IViewComponentResult Invoke()
        {
            return View(books);
        }
    }
}