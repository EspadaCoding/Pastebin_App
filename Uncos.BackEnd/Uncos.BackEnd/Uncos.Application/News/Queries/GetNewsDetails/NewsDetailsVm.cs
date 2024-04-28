using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uncos.Application.Common.Mappings;
using Uncos.Domain;

namespace Uncos.Application.News.Queries.GetNewsDetails
{
    public class NewsDetailsVm:IMapWith<Uncos.Domain.News>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Poster{ get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? EditDate { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Uncos.Domain.News, NewsDetailsVm>()
                .ForMember(newsVm => newsVm.Id,
                    opt => opt.MapFrom(news => news.Id))
                .ForMember(newsVm => newsVm.Title,
                    opt => opt.MapFrom(news => news.Title))
                .ForMember(newsVm => newsVm.Content,
                    opt => opt.MapFrom(news => news.Content))
                  .ForMember(newsVm => newsVm.Poster,
                    opt => opt.MapFrom(news => news.Poster))
                .ForMember(newsVm => newsVm.CreatedDate,
                    opt => opt.MapFrom(news => news.CreatedDate))
                .ForMember(newsVm => newsVm.EditDate,
                    opt => opt.MapFrom(news => news.EditDate));
        }
    }
}
