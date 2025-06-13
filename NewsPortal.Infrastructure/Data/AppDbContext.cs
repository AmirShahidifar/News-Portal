using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NewsPortal.Domain.Entities;

namespace NewsPortal.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<News> News { get; set; }
        public DbSet<NewsCategory> Categories { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<NewsCategory>().HasData(
                new NewsCategory { Id = Guid.NewGuid(), Name = "سیاسی" },
                new NewsCategory { Id = Guid.NewGuid(), Name = "ورزشی" }
            );
        }
    }

}