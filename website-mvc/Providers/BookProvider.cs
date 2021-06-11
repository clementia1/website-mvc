using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System.Linq;
using website_mvc.Entities;

namespace website_mvc.Providers
{
    public class BookProvider
    {
        private readonly ILogger<BookProvider> _logger;
        private readonly List<BookEntity> _entities = new List<BookEntity>();

        public BookProvider(ILogger<BookProvider> logger)
        {
            _logger = logger;
        }

        public async Task<string> CreateAsync(string name, string description)
        {
            _logger.LogInformation($"Started {nameof(CreateAsync)}");
            return await Task.Run(() =>
            {
                var id = Guid.NewGuid().ToString();
                _entities.Add(new BookEntity()
                {
                    Id = id,
                    Description = description,
                    Title = title,
                });

                return id;
            });
        }

        public async Task<bool> UpdateAsync(string id, string? name, string? description)
        {
            _logger.LogInformation($"Started {nameof(UpdateAsync)}");

            return await Task.Run(() =>
            {
                var item = _entities.FirstOrDefault(f => f.Id == id);
                if (item == null)
                {
                    return false;
                }

                item.Name = name;
                item.Description = description;

                return true;
            });
        }

        public async Task<bool> DeleteAsync(string id)
        {
            _logger.LogInformation($"Started {nameof(DeleteAsync)}");
            if (string.IsNullOrEmpty(id))
            {
                return false;
            }

            return await Task.Run(() =>
            {
                var item = _entities.FirstOrDefault(f => f.Id == id);
                if (item == null)
                {
                    return false;
                }

                return _entities.Remove(item);
            });
        }

        public async Task<BookEntity?> GetByIdAsync(string id)
        {
            _logger.LogInformation($"Started {nameof(GetByIdAsync)}");
            return await Task.Run(() =>
            {
                return _entities.FirstOrDefault(f => f.Id == id);
            });
        }
    }
}