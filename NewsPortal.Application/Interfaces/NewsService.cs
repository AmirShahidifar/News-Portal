using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsPortal.Application.Interfaces
{
public class NewsService : INewsService
{
    private readonly INewsRepository _repo;

    public NewsService(INewsRepository repo)
    {
        _repo = repo;
    }

    public async Task<List<News>> GetAllAsync() => await _repo.GetAllAsync();
    public async Task<News?> GetByIdAsync(Guid id) => await _repo.GetByIdAsync(id);
    public async Task CreateAsync(News news)
    {
        news.CreatedAt = DateTime.UtcNow;
        await _repo.CreateAsync(news);
    }
    public async Task UpdateAsync(News news) => await _repo.UpdateAsync(news);
    public async Task DeleteAsync(Guid id) => await _repo.DeleteAsync(id);
}

}