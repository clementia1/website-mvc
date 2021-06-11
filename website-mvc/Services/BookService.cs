using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using website_mvc.Entities;

namespace website_mvc.Services
{
    public class BookService
    {
        private readonly ILogger<ManageService> _logger;
        private readonly IBookProvider _bookProvider;

        public ManageService(
            ILogger<ManageService> logger,
            IBookProvider bookProvider)
        {
            _logger = logger;
            _bookProvider = bookProvider;
        }

        public async Task<string> CreateAsync(string name, string description)
        {
            _logger.LogInformation($"Started {nameof(CreateAsync)}");
            return await _bookProvider.CreateAsync(name, description);
        }

        public async Task<bool> UpdateAsync(string id, string? name, string? description)
        {
            _logger.LogInformation($"Started {nameof(UpdateAsync)}");
            return await _bookProvider.UpdateAsync(id, name, description);
        }

        public async Task<bool> DeleteAsync(string id)
        {
            _logger.LogInformation($"Started {nameof(DeleteAsync)}");
            return await _bookProvider.DeleteAsync(id);
        }

        public async Task<BookEntity?> GetByIdAsync(string id)
        {
            _logger.LogInformation($"Started {nameof(GetByIdAsync)}");
            return await _bookProvider.GetByIdAsync(id);
        }
    }
}