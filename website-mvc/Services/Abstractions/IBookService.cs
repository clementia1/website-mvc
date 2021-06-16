using System.Collections.Generic;
using System.Threading.Tasks;
using website_mvc.Dto;
using website_mvc.Entities;

namespace website_mvc.Services.Abstractions
{
    public interface IBookService
    {
        Task<BookEntity?> GetById(string id);
        Task<IReadOnlyCollection<BookEntity>?> GetAll();
    }
}