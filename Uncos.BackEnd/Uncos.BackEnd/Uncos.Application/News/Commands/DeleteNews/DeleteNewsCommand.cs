using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uncos.Application.News.Commands.DeleteNews
{
    public class DeleteNewsCommand:IRequest
    {
        public Guid userId { get; set; }
        public Guid Id { get; set; }
    }
}
