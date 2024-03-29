using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uncos.Application.Interfaces;

namespace Uncos.Application.News.Queries.GetNewsList
{
    public class GetNewsListQueryHandler
        : IRequestHandler<GetNewsListQuery, NewsListVm>
    {
        private readonly IUncosDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetNewsListQueryHandler(IUncosDbContext dbContext, IMapper mapper)
        => (_dbContext, _mapper) = (dbContext, mapper);
        public async Task<NewsListVm> Handle(GetNewsListQuery request, CancellationToken cancellationToken)
        {
             var newsQuery= await _dbContext.News
                                  .Where(news=>news.userId == request.userId)
                                  .ProjectTo<NewsLookUpDto>(_mapper.ConfigurationProvider)
                                  .ToListAsync(cancellationToken);

            return new NewsListVm { News = newsQuery };
        }
    }
}
