using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uncos.Application.Interfaces;
using Uncos.Application.Common.Exeptions;
using Microsoft.Data.SqlClient;

namespace Uncos.Application.News.Commands.UpdateNews
{
    public class UpdateNewsCommandHandler 
        : IRequestHandler<UpdateNewsCommand>
          
    {
        private readonly IUncosDbContext _dbContext;
        public UpdateNewsCommandHandler(IUncosDbContext dbContext)
        => _dbContext = dbContext;

        public async Task Handle(UpdateNewsCommand request, CancellationToken cancellationToken)
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
                entity.Poster= request.Poster;
               entity.CategoryId = request.CategoryId;
            try
            {
                await _dbContext.SaveChangesAsync(cancellationToken);
            }
            catch (DbUpdateException ex)
            {
                // Handle or log the exception
                Console.WriteLine("An error occurred while saving changes: " + ex.Message);

                // Check if there is an inner exception
                if (ex.InnerException != null)
                {
                    if (ex.InnerException is SqlException sqlEx)
                    {
                        // Handle specific SQL exception
                        Console.WriteLine("SQL error code: " + sqlEx.Number);
                    }
                    Console.WriteLine("Inner exception: " + ex.InnerException.Message);
                }
                throw;
            } 
        }
    }
}
