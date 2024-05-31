using Microsoft.EntityFrameworkCore;
using Uncos.Domain;

namespace Uncos.Application.Interfaces
{
    public interface IUncosDbContext
    {
        DbSet<Uncos.Domain.News> News { get; set; }
        DbSet<Category> Categories { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
