using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uncos.Domain;

namespace Uncos.Application.News.Commands.CreateNews
{
    public class CreateNewsCommand:IRequest<Guid>
    {
        public Guid userId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public FILE Poster { get; set; } 
    }
}
