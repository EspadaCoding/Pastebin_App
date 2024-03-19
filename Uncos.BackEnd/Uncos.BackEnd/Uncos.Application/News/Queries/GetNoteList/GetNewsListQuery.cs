using MediatR;

namespace Uncos.Application.News.Queries.GetNoteList
{
    public class GetNewsListQuery:IRequest<NewsListVm>
    {
        public Guid userId { get; set; }
    }
}
