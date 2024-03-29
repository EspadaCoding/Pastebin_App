using AutoMapper;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Uncos.Application.News.Queries.GetNewsList;
using Uncos.Application.News.Queries.GetNewsDetails;
using Uncos.Application.News.Commands.CreateNews;
using Uncos.Application.News.Commands.UpdateNews;
using Uncos.Application.News.Commands.DeleteNews;
using Uncos.WebAPI.Models;
namespace Uncos.WebAPI.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Produces("application/json")]
    public class NewsController : BaseController
    {
        private readonly IMapper _mapper;

        public NewsController(IMapper mapper) => _mapper = mapper;

        [HttpGet]  
        [Route("GetAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<NewsListVm>> GetAll()
        {
            var query = new GetNewsListQuery
            {
                userId = UserId
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet] 
        [Route("GetById/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<NewsListVm>> Get(Guid id)
        {
            var query = new GetNewsDetailsQuery
            {
                userId = UserId,
                Id = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromForm] CreateNewsDto createNewsDto)
        {
            var command = _mapper.Map<CreateNewsCommand>(createNewsDto);
            command.userId = UserId;
            var NewsId = await Mediator.Send(command);
            return Ok(NewsId);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromForm] UpdateNewsDto updateNewsDto)
        {
            var command = _mapper.Map<UpdateNewsCommand>(updateNewsDto);
            command.userId = UserId;
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteNewsCommand
            {
                Id = id,
                userId = UserId
            };
            await Mediator.Send(command);
            return NoContent();
        }


    }
}
