using AutoMapper;
using Uncos.Application.Common.Mappings;
using Uncos.Application.News.Commands.UpdateNews;
using Uncos.Domain;

namespace Uncos.WebAPI.Models
{
    public class UpdateNewsDto : IMapWith<UpdateNewsCommand>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Poster { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateNewsDto, UpdateNewsCommand>()
                .ForMember(noteCommand => noteCommand.Id,
                    opt => opt.MapFrom(noteDto => noteDto.Id))
                .ForMember(noteCommand => noteCommand.Title,
                    opt => opt.MapFrom(noteDto => noteDto.Title))
                .ForMember(noteCommand => noteCommand.Content,
                    opt => opt.MapFrom(noteDto => noteDto.Content))
                 .ForMember(noteCommand => noteCommand.Poster,
                    opt => opt.MapFrom(noteDto => noteDto.Poster));
        }
    }
}