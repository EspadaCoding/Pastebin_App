using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uncos.Application.Categories.Queries.GetCategory;
using Uncos.Application.Interfaces;

namespace Uncos.Application.News.Queries.GetAllNewsList
{
    public class GetAllNewsQueryHandler : IRequestHandler<GetAllNewsQuery, AllNewsListVm>
    {
        private readonly IUncosDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetAllNewsQueryHandler(IUncosDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<AllNewsListVm> Handle(GetAllNewsQuery request, CancellationToken cancellationToken)
        {
            var newsQuery = await _dbContext.News.ToListAsync(cancellationToken);
            var newsDtoList = _mapper.Map<List<NewsDto>>(newsQuery);
            var vm = new AllNewsListVm { News = newsDtoList };
            return vm;
        }
    }

}
