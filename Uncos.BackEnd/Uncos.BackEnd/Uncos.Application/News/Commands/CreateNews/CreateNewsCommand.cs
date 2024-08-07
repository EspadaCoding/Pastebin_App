using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uncos.Domain;

namespace Uncos.Application.News.Commands.CreateNews
{
    public class CreateNewsCommand : IRequest<Guid>
    {
        public Guid userId { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Content { get; set; } = string.Empty;
         
        public string Poster { get; set; } = string.Empty;

        [Required]
        public string Username { get; set; } = string.Empty;

        [Required]
        public Guid CategoryId { get; set; }
    }

}
