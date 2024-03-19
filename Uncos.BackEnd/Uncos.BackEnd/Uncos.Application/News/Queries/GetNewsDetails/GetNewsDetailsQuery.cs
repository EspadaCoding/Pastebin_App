using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uncos.Application.News.Queries.GetNewsDetails
{
    public class GetNewsDetailsQuery:IRequest<NewsDetailsVm>
    {
        public Guid Id { get; set; }
        public Guid userId { get; set; }

    }
}
