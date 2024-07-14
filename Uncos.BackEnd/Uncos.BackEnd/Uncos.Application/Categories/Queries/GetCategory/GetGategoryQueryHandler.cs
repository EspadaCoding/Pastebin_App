using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Uncos.Application.Common.Exeptions;
using Uncos.Application.Interfaces;
using Uncos.Application.News.Queries.GetNewsDetails;
using Uncos.Application.News.Queries.GetNewsList;

namespace Uncos.Application.Categories.Queries.GetCategory
{
    public class GetCategoryQueryHandler
        : IRequestHandler<GetGategoryQuery, List<GetCategoryVm>>
    {

        private readonly IUncosDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetCategoryQueryHandler(IUncosDbContext dbContext, IMapper mapper)
            => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<List<GetCategoryVm>> Handle(GetGategoryQuery request, CancellationToken cancellationToken)
        {
            var categoryQuery = await _dbContext.Categories.ToListAsync(cancellationToken);

            return _mapper.Map<List<GetCategoryVm>>(categoryQuery);
        }
    }
} 