using Microsoft.EntityFrameworkCore; 

namespace Uncos.Application.Interfaces
{
    public interface IUncosDbContext
    {
        DbSet<Uncos.Domain.News> News { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
