using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using website_mvc.Dto;
using website_mvc.Entities;
using website_mvc.Services.Abstractions;

namespace website_mvc.Services
{
    public class BookService : IBookService
    {
        private readonly HttpClient _client;

        public BookService(HttpClient httpClient)
        {
            _client = httpClient;
        }

        public async Task<BookEntity?> GetById(string id)
        {
            return await _client.GetFromJsonAsync<BookEntity>($"get/{id}");
        }

        public async Task<IReadOnlyCollection<BookEntity>?> GetAll()
        {
            return await _client.GetFromJsonAsync<IReadOnlyCollection<BookEntity>>("Get");
        }
    }
}