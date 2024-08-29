using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uncos.Domain;

namespace Uncos.Application.Interfaces
{
    public interface ISaveService
    {
        Task<Save> GetSaveByNewsAndUserAsync(Guid newsId, Guid userId);
        Task AddSaveAsync(Save save);
        Task DeleteSaveAsync(Save save);
    }
}
