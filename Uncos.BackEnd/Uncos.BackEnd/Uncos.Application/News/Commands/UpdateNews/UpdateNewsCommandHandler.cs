using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uncos.Application.Interfaces;
using Uncos.Application.Common.Exeptions;

namespace Uncos.Application.News.Commands.UpdateNews
{
    public class UpdateNewsCommandHandler 
        : IRequestHandler<UpdateNewsCommand>
          
    {
        private readonly INewsDbContexts _dbContext;
        public UpdateNewsCommandHandler(INewsDbContexts dbContext)
        => _dbContext = dbContext;

        public async Task<Unit> Handle(UpdateNewsCommand request, CancellationToken cancellationToken)
        { 
                var entity = await _dbContext.News.FirstOrDefaultAsync(
                    news => news.Id == request.Id, cancellationToken);
                if (entity == null || entity.userId != request.userId)
                {
                    throw new NotFoundException(nameof(Uncos.Domain.News), request.Id);
                }
                entity.Title = request.Title;
                entity.Content = request.Content;
                entity.EditDate = DateTime.Now;
                await _dbContext.SaveChangesAsync(cancellationToken);
                return Unit.Value; 
        }
    }
}
