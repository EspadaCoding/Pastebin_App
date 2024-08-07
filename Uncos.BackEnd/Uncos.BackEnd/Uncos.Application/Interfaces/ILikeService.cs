using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uncos.Domain;

namespace Uncos.Application.Interfaces
{
    public interface ILikeService
    {
        Task<Like> GetLikeByNewsAndUserAsync(Guid newsId, Guid userId);
        Task AddLikeAsync(Like like);
        Task DeleteLikeAsync(Like like);
    }

}
