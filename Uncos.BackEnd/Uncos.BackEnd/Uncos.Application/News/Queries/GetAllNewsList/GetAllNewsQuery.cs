using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uncos.Application.News.Queries.GetAllNewsList
{
    public class GetAllNewsQuery : IRequest<AllNewsListVm>
    {
        // Add any query-specific properties here if needed
    }
}
