using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uncos.Application.Interfaces
{
    public interface INewsService
    {
        Task<Uncos.Domain.News> FindNewsByIdAsync(Guid id);
        Task EditNewsAsync(Uncos.Domain.News news);
    }

}
