using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NewsPortal.Domain.Entities;

namespace NewsPortal.Application.Interfaces
{
 public interface INewsService
{
    Task<List<News>> GetAllAsync();
    Task<News?> GetByIdAsync(Guid id);
    Task CreateAsync(News news);
    Task UpdateAsync(News news);
    Task DeleteAsync(Guid id);
}

}