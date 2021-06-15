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
        private readonly ILogger<BookService> _logger;
        private readonly HttpClient _client;

        public BookService(
            ILogger<BookService> logger,
            HttpClient httpClient)
        {
            _logger = logger;
            _client = httpClient;
        }

        public async Task<string> Create(BookDto bookDto)
        {
            var response = await _client.PostAsJsonAsync("post", bookDto);
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<bool> Update(BookDto bookDto)
        {
            var response = await _client.PutAsJsonAsync("put", bookDto);
            return response.StatusCode == HttpStatusCode.OK ? true : false;
        }

        public async Task<bool> Delete(string id)
        {
            var response = await _client.DeleteAsync($"delete/{id}");
            return response.StatusCode == HttpStatusCode.NoContent ? true : false;
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