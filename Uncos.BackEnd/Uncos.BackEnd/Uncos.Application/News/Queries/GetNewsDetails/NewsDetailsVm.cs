using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uncos.Application.Common.Mappings;
using Uncos.Application.News.Queries.GetAllNewsList;
using Uncos.Domain;

namespace Uncos.Application.News.Queries.GetNewsDetails
{
    public class NewsDetailsVm:IMapWith<Uncos.Domain.News>
    {
        public Guid Id { get; set; }
        public Guid userId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Username { get; set; }
        public string Poster { get; set; }
        public int Likes { get; set; }
        public bool ItSaved { get; set; }
        public bool ItLiked { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid CategoryId { get; set; }
        public int CountofComments { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Uncos.Domain.News, NewsDto>()
                .ForMember(newsDto => newsDto.Id,
                    opt => opt.MapFrom(news => news.Id))
                .ForMember(newsDto => newsDto.Title,
                    opt => opt.MapFrom(news => news.Title))
                .ForMember(newsDto => newsDto.Content,
                    opt => opt.MapFrom(news => news.Content))
                .ForMember(newsDto => newsDto.Username,
                    opt => opt.MapFrom(news => news.Username))
                .ForMember(newsDto => newsDto.Poster,
                    opt => opt.MapFrom(news => news.Poster))
                .ForMember(newsDto => newsDto.Likes,
                    opt => opt.MapFrom(news => news.Likes))
                .ForMember(newsDto => newsDto.ItSaved,
                    opt => opt.MapFrom(news => news.ItSaved))
                .ForMember(newsDto => newsDto.ItLiked,
                    opt => opt.MapFrom(news => news.ItLiked))
                .ForMember(newsDto => newsDto.CreatedDate,
                    opt => opt.MapFrom(news => news.CreatedDate))
                .ForMember(newsDto => newsDto.CategoryId,
                    opt => opt.MapFrom(news => news.CategoryId))
                .ForMember(newsDto => newsDto.CountofComments,
                    opt => opt.MapFrom(news => news.CountofComments));
        }
    }
} 
