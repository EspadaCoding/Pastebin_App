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
using Uncos.Application.News.Queries.GetUserNewsList;

namespace Uncos.Application.News.Queries.GetNewsList
{
    public class GetUserNewsListQueryHandler
        : IRequestHandler<GetUserNewsListQuery, UserNewsListVm>
    {
        private readonly IUncosDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetUserNewsListQueryHandler(IUncosDbContext dbContext, IMapper mapper)
        => (_dbContext, _mapper) = (dbContext, mapper);
        public async Task<UserNewsListVm> Handle(GetUserNewsListQuery request, CancellationToken cancellationToken)
        {
             var newsQuery= await _dbContext.News
                                  .Where(news=>news.userId == request.userId)
                                  .ProjectTo<NewsLookUpDto>(_mapper.ConfigurationProvider)
                                  .ToListAsync(cancellationToken);

            return new UserNewsListVm { News = newsQuery };
        }
    }
}
