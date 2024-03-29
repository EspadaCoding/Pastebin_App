using MediatR;

namespace Uncos.Application.News.Queries.GetNewsList
{
    public class GetNewsListQuery:IRequest<NewsListVm>
    {
        public Guid userId { get; set; }
    }
}
