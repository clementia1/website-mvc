using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using website_mvc.Entities;
using website_mvc.Providers.Abstractions;

namespace website_mvc.Providers
{
    public class BookProvider : IBookProvider
    {
        private readonly ILogger<BookProvider> _logger;
        private readonly List<BookEntity> _entities;

        public BookProvider(ILogger<BookProvider> logger, HttpClient client)
        {
            _logger = logger;
            client.BaseAddress = new Uri("https://localhost:40001");
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("User-Agent", "HttpClientFactory");

            Client = client;
            
            _entities = new List<BookEntity>
            {
                new BookEntity
                {
                    Id = "1",
                    Title = "Effective C# (Covers C# 6.0), (includes Content Update Program)",
                    Author = "Bill Wagner",
                    Description = "Effective C# is a book written by Bill Wagner. The book helps the programmer to write exceptionally robust and well-performing code. The writer's clear, practical explanations, expert tips, and realistic code examples have made Effective C# indispensable to hundreds of thousands of developers."
                },
                new BookEntity
                {
                    Id = "2",
                    Title = "C# 8.0 Pocket Reference: Instant Help for C# 8.0 Programmers",
                    Author = "Joseph Albahari",
                    Description = "C# 8.0 Pocket Reference is a book written by Joseph Albahari. It is an ideal book and quick source of information that helps or as a guide to rapidly speed up if you know Java, C++, or some earlier C# versions. All C# programs and code snippets are available as interactive samples in LINQPad. You create these samples and have results without the need to set up projects in Visual Studio."
                },
                new BookEntity
                {
                    Id = "3",
                    Title = "Pro C# 7: With .NET and .NET Core",
                    Author = "Andrew Troelsen and Philip Japikse",
                    Description = "Pro C# 7: With .NET and .NET Core is a book written by Andrew Troelsen and Philip Japikse. The book provides a comprehensive foundation in the C# programming language and the frameworks it lives in. The book covers C# 7.1 and .NET 4.7 features along with dedicated chapters on Microsoft's lightweight, cross-platform framework. The book also includes NET Core 2.0. Coverage and ASP.NET Core, Entity Framework (EF) Core. Communication Foundation (WCF), and ASP.NET MVC."
                },
                new BookEntity
                {
                    Id = "4",
                    Title = "Agile Principles, Patterns, and Practices in C#",
                    Author = "Robert C. Martin and Micah Martin",
                    Description = "Agile Principles, Patterns, and Practices in C# is a book written by Robert C. Martin and Micah Martin. This reference book presents a series of case studies that help to illustrate the fundamentals of C# language. Agile development and Agile design, and moves also quickly allow from UML models to real C# code. The beginning chapters teach you the basics of the agile movement, while the later chapters show many proven techniques. The reference includes many source code examples that are also available for download from the authors' Website."
                },
                new BookEntity
                {
                    Id = "5",
                    Title = "Concurrency in C# Cookbook: Asynchronous, Parallel, and Multithreaded Programming",
                    Author = "Stephen Cleary",
                    Description = "Concurrency in C# Cookbook is a book written by Stephen Cleary demonstrates parallel processing and asynchronous programming techniques by using libraries and language features in .NET and C# 8.0. This cookbook also shows you how modern tools help you to make the level of abstraction, making concurrency much easier and effective. The book offer ready-to-use code and discussions about how and why solutions work, these recipes help you, to solve numerous C# solutions."
                }
            };
        }
        
        public HttpClient Client { get; }

        public async Task<string> Create(string title, string author, string description)
        {
            return await Task.Run(() =>
            {
                var id = Guid.NewGuid().ToString();
                _entities.Add(new BookEntity()
                {
                    Id = id,
                    Author = author,
                    Description = description,
                    Title = title,
                });

                return id;
            });
        }

        public async Task<bool> Update(string id, string? title, string? author, string? description)
        {
            return await Task.Run(() =>
            {
                var book = _entities.FirstOrDefault(item => item.Id == id);
                if (book is null) return false;

                book.Title = title;
                book.Author = author;
                book.Description = description;

                return true;
            });
        }

        public async Task<bool> Delete(string id)
        {
            if (string.IsNullOrEmpty(id)) return false;

            return await Task.Run(() =>
            {
                var item = _entities.FirstOrDefault(item => item.Id == id);
                return item != null && _entities.Remove(item);
            });
        }

        public async Task<BookEntity> GetById(string id)
        {
            return await Client.GetFromJsonAsync<BookEntity>(id);
        }

        public async Task<IReadOnlyCollection<BookEntity>> GetAll()
        {
            return await Task.FromResult(_entities);
        }
    }
}