using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uncos.Application.News.Queries.GetNewsDetails;

namespace Uncos.Application.Categories.Queries.GetCategory
{

    public class GetGategoryQuery : IRequest<List<GetCategoryVm>>
    {
         
    }
}
