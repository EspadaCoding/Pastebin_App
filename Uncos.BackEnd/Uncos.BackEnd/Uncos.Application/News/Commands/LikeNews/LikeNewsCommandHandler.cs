using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uncos.Application.Common.Exeptions;
using Uncos.Application.Interfaces;
using Uncos.Domain;

namespace Uncos.Application.News.Commands.LikeNews
{
    public class LikeNewsCommandHandler : IRequestHandler<LikeNewsCommand>
    {
        private readonly ILikeService _likeService;
        private readonly INewsService _newsService;

        public LikeNewsCommandHandler(ILikeService likeService, INewsService newsService)
        {
            _likeService = likeService;
            _newsService = newsService;
        }

        public async Task Handle(LikeNewsCommand request, CancellationToken cancellationToken)
        {
            var art = await _newsService.FindNewsByIdAsync(request.NewsId);
            if (art == null)
            {
                throw new InvalidOperationException("News not found.");
            }

            var existingLike = await _likeService.GetLikeByNewsAndUserAsync(art.Id, request.UserId);

            if (existingLike == null)
            {
                var like = new Like
                {
                    NewsId = art.Id,
                    UserID = request.UserId,
                    LikedDate = DateTime.Now,
                    Liked = true
                };

                art.Likes++;
                await _newsService.EditNewsAsync(art);
                await _likeService.AddLikeAsync(like);
            }
            else
            {
                art.Likes--;
                await _newsService.EditNewsAsync(art);
                await _likeService.DeleteLikeAsync(existingLike);
            }
        }
    }

}
