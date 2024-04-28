using AutoMapper;
using Uncos.Application.Common.Mappings;
using Uncos.Application.News.Commands.CreateNews;
using Uncos.Domain;
namespace Uncos.WebAPI.Models
{
    public class CreateNewsDto : IMapWith<CreateNewsCommand>
    {
        public string Title { get; set; } 
        public string Content { get;  set; }
        public string Poster { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateNewsDto, CreateNewsCommand>()
                .ForMember(newsCommand => newsCommand.Title,
                    opt => opt.MapFrom(newsDto => newsDto.Title))
                .ForMember(newsCommand => newsCommand.Content,
                    opt => opt.MapFrom(newsDto => newsDto.Content))
                  .ForMember(newsCommand => newsCommand.Poster,
                    opt => opt.MapFrom(newsDto => newsDto.Poster));
        }

    }
}

