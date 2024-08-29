using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uncos.Application.Interfaces;
using Uncos.Domain;

namespace Uncos.Application.News.Commands.SaveNews
{
    public class SaveNewsCommandHandler : IRequestHandler<SaveNewsCommand>
    {
        private readonly ISaveService _saveService;
        private readonly INewsService _newsService;

        public SaveNewsCommandHandler(ISaveService saveService, INewsService newsService)
        {
            _saveService = saveService;
            _newsService = newsService;
        }

        public async Task Handle(SaveNewsCommand request, CancellationToken cancellationToken)
        {
            var art = await _newsService.FindNewsByIdAsync(request.NewsId);
            if (art == null)
            {
                throw new InvalidOperationException("News not found.");
            }

            var existingSave = await _saveService.GetSaveByNewsAndUserAsync(art.Id, request.UserId);

            if (existingSave == null)
            {
                var save = new Save
                {
                    NewsId = art.Id,
                    UserID = request.UserId,
                    SavedDate = DateTime.Now,
                    Saved = true
                };

                await _saveService.AddSaveAsync(save);
            }
            else
            {
                await _saveService.DeleteSaveAsync(existingSave);
            }
        }
    }

}
