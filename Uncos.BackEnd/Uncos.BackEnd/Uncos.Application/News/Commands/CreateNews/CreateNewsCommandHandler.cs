using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
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
        private readonly IUncosDbContext _dbContext;
        public CreateNewsCommandHandler(IUncosDbContext dbContext)
        => _dbContext = dbContext;

        public async Task<Guid> Handle(CreateNewsCommand request, 
            CancellationToken cancellationToken)

        {

             var categoryExists = await _dbContext.Categories.AnyAsync(c => c.Id == request.CategoryId, cancellationToken);
             if (!categoryExists)
             {
                 throw new ArgumentException($"Категория с Id '{request.CategoryId}' не существует.");
             }

            var news = new Uncos.Domain.News
            {
                userId = request.userId,
                Id = Guid.NewGuid(),
                Title = request.Title,
                Content = request.Content,
                Poster = request.Poster,
                CreatedDate = DateTime.Now ,
                EditDate = null ,
                CategoryId = request.CategoryId
            };
            await _dbContext.News.AddAsync(news, cancellationToken);
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

            return news.Id;
        }
    }
}
