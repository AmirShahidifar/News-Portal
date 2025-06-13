using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NewsPortal.Application.Interfaces;
using NewsPortal.Domain.Entities;
using NewsPortal.Infrastructure.Data;

namespace NewsPortal.Infrastructure.Repositories
{
    public class NewsRepository : INewsRepository
    {
        private readonly AppDbContext _context;

        public NewsRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<News>> GetAllAsync() =>
            await _context.News.Include(n => n.Category).ToListAsync();

        public async Task<News?> GetByIdAsync(Guid id) =>
            await _context.News.Include(n => n.Category).FirstOrDefaultAsync(n => n.Id == id);

        public async Task CreateAsync(News news)
        {
            await _context.News.AddAsync(news);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(News news)
        {
            _context.News.Update(news);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var news = await _context.News.FindAsync(id);
            if (news is not null)
            {
                _context.News.Remove(news);
                await _context.SaveChangesAsync();
            }
        }
    }

}