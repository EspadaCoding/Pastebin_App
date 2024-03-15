using Microsoft.EntityFrameworkCore; 

namespace Uncos.Application.Interfaces
{
    public interface INewsDbContexts
    {
        DbSet<Uncos.Domain.News> News { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
