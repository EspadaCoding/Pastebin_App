using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uncos.Application.Common.Mappings;
using Uncos.Domain;

namespace Uncos.Application.Categories.Queries.GetCategory
{ 

    public class GetCategoryVm : IMapWith<Category>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Category, GetCategoryVm>()
                .ForMember(categoryVm => categoryVm.Id,
                    opt => opt.MapFrom(news => news.Id))
                 .ForMember(newsVm => newsVm.Name,
                    opt => opt.MapFrom(news => news.Name));
        }
    }
}
