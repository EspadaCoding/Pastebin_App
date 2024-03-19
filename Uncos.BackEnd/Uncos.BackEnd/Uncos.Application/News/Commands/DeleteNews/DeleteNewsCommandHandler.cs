using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uncos.Application.Common.Exeptions;
using Uncos.Application.Interfaces;
using Uncos.Application.News.Commands.CreateNews;
using Uncos.Domain;

namespace Uncos.Application.News.Commands.DeleteNews
{
    public class DeleteNewsCommandHandler : IRequestHandler<DeleteNewsCommand>
    {
        private readonly INewsDbContexts _dbContext;
        public DeleteNewsCommandHandler(INewsDbContexts dbContext)
        => _dbContext = dbContext;

        public async Task<Unit> Handle(DeleteNewsCommand request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.News.FindAsync(new object[] { request.Id },cancellationToken);
            if (entity == null && entity.userId !=request.userId)
            {
                throw new NotFoundException(nameof(Uncos.Domain.News), request.Id);
            }
            _dbContext.News.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
