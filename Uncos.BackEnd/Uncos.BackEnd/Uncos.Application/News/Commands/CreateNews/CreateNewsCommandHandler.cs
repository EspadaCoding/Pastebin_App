using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Uncos.Application.Interfaces;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Uncos.Application.News.Commands.CreateNews
{
    public class CreateNewsCommandHandler
        : IRequestHandler<CreateNewsCommand, Guid>
    {
        private readonly INewsDbContexts _dbContext;
        public CreateNewsCommandHandler(INewsDbContexts dbContext)
        => _dbContext = dbContext;

        public async Task<Guid> Handle(CreateNewsCommand request, 
            CancellationToken cancellationToken)
        {
            var news = new Uncos.Domain.News
            {
                userId = request.userId,
                Id = Guid.NewGuid(),
                Title = request.Title,
                Content = request.Content,
                PosterUrl = request.PosterUrl,
                CreatedDate = DateTime.Now ,
                 EditDate = null ,
            };
            await _dbContext.News.AddAsync(news, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return news.Id;
        }
    }
}
