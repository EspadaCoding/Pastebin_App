using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Uncos.Application.Interfaces;
using Uncos.Domain;
using Uncos.Persistence;

public class LikeService : ILikeService
{
    private readonly UncosDbContext _context;

    public LikeService(UncosDbContext context)
    {
        _context = context;
    }

    public async Task<Like> GetLikeByNewsAndUserAsync(Guid newsId, Guid userId)
    {
        return await _context.Likes
            .FirstOrDefaultAsync(l => l.NewsId == newsId && l.UserID == userId);
    }

    public async Task AddLikeAsync(Like like)
    {
        _context.Likes.Add(like);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteLikeAsync(Like like)
    {
        _context.Likes.Remove(like);
        await _context.SaveChangesAsync();
    }
}
