using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uncos.Application.News.Queries.GetNoteList
{
    public class NewsListVm
    {
        public IList<NewsLookUpDto> News { get; set; }
    }
}
