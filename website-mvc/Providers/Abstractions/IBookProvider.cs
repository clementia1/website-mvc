﻿using System.Collections.Generic;
using System.Threading.Tasks;
using website_mvc.Entities;

namespace website_mvc.Providers.Abstractions
{
    public interface IBookProvider
    {
        Task<string> Create(string title, string author, string description);
        Task<bool> Update(string id, string? title, string? author, string? description);
        Task<bool> Delete(string id);
        Task<BookEntity> GetById(string id);
        Task<IReadOnlyCollection<BookEntity>> GetAll();
    }
}