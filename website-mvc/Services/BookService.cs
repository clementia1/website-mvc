using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using website_mvc.Entities;
using website_mvc.Providers.Abstractions;
using website_mvc.Services.Abstractions;

namespace website_mvc.Services
{
    public class BookService : IBookService
    {
        private readonly ILogger<BookService> _logger;
        private readonly IBookProvider _bookProvider;

        public BookService(
            ILogger<BookService> logger,
            IBookProvider bookProvider)
        {
            _logger = logger;
            _bookProvider = bookProvider;
        }

        public async Task<string> Create(string title, string author, string description)
        {
            return await _bookProvider.Create(title, author, description);
        }

        public async Task<bool> Update(string id, string? title, string? author, string? description)
        {
            return await _bookProvider.Update(id, title, author, description);
        }

        public async Task<bool> Delete(string id)
        {
            return await _bookProvider.Delete(id);
        }

        public async Task<BookEntity> GetById(string id)
        {
            return await _bookProvider.GetById(id);
        }

        public async Task<IReadOnlyCollection<BookEntity>> GetAll()
        {
            return await _bookProvider.GetAll();
        }
    }
}