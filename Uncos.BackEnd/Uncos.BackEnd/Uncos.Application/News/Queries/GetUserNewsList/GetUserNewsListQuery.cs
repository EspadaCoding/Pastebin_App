using MediatR;

namespace Uncos.Application.News.Queries.GetUserNewsList
{
    public class GetUserNewsListQuery:IRequest<UserNewsListVm>
    {
        public Guid userId { get; set; }
    }
}
