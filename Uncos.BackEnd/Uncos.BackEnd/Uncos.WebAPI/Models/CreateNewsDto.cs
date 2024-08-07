using AutoMapper;
using System.ComponentModel.DataAnnotations;
using Uncos.Application.Common.Mappings;
using Uncos.Application.News.Commands.CreateNews;
using Uncos.Domain;
namespace Uncos.WebAPI.Models
{
    public class CreateNewsDto : IMapWith<CreateNewsCommand>
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; } 
        public string Poster { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public Guid CategoryId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateNewsDto, CreateNewsCommand>()
                .ForMember(newsCommand => newsCommand.Title, opt => opt.MapFrom(newsDto => newsDto.Title))
                .ForMember(newsCommand => newsCommand.Content, opt => opt.MapFrom(newsDto => newsDto.Content))
                .ForMember(newsCommand => newsCommand.Poster, opt => opt.MapFrom(newsDto => newsDto.Poster))
                .ForMember(newsCommand => newsCommand.Username, opt => opt.MapFrom(newsDto => newsDto.Username))
                .ForMember(newsCommand => newsCommand.CategoryId, opt => opt.MapFrom(newsDto => newsDto.CategoryId));
        }
    }
}

