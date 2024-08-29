using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uncos.Application.News.Commands.SaveNews
{
    public class SaveNewsCommand : IRequest
    {
        public Guid NewsId { get; set; }
        public Guid UserId { get; set; }
    }

}
