namespace Uncos.WebAPI.Services
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using Uncos.Application.Interfaces;
    using Uncos.Domain;
    using Uncos.Persistence;

    public class SaveService : ISaveService
    {
        private readonly UncosDbContext _context;

        public SaveService(UncosDbContext context)
        {
            _context = context;
        }

        public async Task<Save> GetSaveByNewsAndUserAsync(Guid newsId, Guid userId)
        {
            return await _context.Saves
                .FirstOrDefaultAsync(s => s.NewsId == newsId && s.UserID == userId);
        }

        public async Task AddSaveAsync(Save save)
        {
            _context.Saves.Add(save);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSaveAsync(Save save)
        {
            _context.Saves.Remove(save);
            await _context.SaveChangesAsync();
        }
    }

}
