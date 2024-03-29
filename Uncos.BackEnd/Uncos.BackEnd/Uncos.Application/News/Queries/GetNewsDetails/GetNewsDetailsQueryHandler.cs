using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uncos.Application.Common.Exeptions;
using Uncos.Application.Interfaces;
using Uncos.Application.News.Commands.CreateNews;
using Uncos.Domain;

namespace Uncos.Application.News.Queries.GetNewsDetails
{
    public class GetNewsDetailsQueryHandler
        : IRequestHandler<GetNewsDetailsQuery, NewsDetailsVm>
    {
        private readonly IUncosDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetNewsDetailsQueryHandler(IUncosDbContext dbContext,IMapper mapper)
        => (_dbContext,_mapper) = (dbContext,mapper);

        public async Task<NewsDetailsVm> Handle(GetNewsDetailsQuery request,
            CancellationToken cancellationToken)
        {


            var entity = await _dbContext.News
               .FirstOrDefaultAsync(news =>
               news.Id == request.Id, cancellationToken);
            if (entity == null || entity.userId !=request.userId)
            {
                throw new NotFoundException(nameof(Uncos.Domain.News), request.Id);
            }
             


            return _mapper.Map<NewsDetailsVm>(entity);
        } 
    }
}
