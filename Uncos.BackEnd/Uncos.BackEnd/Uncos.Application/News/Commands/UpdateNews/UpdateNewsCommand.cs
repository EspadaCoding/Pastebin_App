using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uncos.Domain;

namespace Uncos.Application.News.Commands.UpdateNews
{
    public class UpdateNewsCommand:IRequest
    {
        public Guid userId { get; set; }
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Poster { get; set; }
        public Guid CategoryId { get; set; }

    }
}
