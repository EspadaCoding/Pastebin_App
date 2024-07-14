using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uncos.Application.News.Queries.GetUserNewsList
{
    public class UserNewsListVm
    {
        public IList<NewsLookUpDto> News { get; set; }
    }
}
