using Uncos.Application.Interfaces;
using Uncos.Domain;
using Uncos.Persistence;

namespace Uncos.WebAPI.Services
{
    public class NewsService : INewsService
    {
        private readonly UncosDbContext _context;

        public NewsService(UncosDbContext context)
        {
            _context = context;
        }

        public async Task<News> FindNewsByIdAsync(Guid id)
        {
            return await _context.News.FindAsync(id);
        }

        public async Task EditNewsAsync(News news)
        {
            _context.News.Update(news);
            await _context.SaveChangesAsync();
        }
    }
}
