using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uncos.Application.Common.Mappings;

namespace Uncos.Application.News.Queries.GetUserNewsList
{
    public class NewsLookUpDto:IMapWith<Uncos.Domain.News>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Uncos.Domain.News, NewsLookUpDto>()
                .ForMember(newsDto => newsDto.Id,
                    opt => opt.MapFrom(news => news.Id))
                .ForMember(newsDto => newsDto.Title,
                    opt => opt.MapFrom(news => news.Title));
        }
    }
}
