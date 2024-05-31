using AutoMapper; 
using Microsoft.AspNetCore.Mvc;
using Uncos.Application.News.Queries.GetNewsList;
using Uncos.Application.News.Queries.GetNewsDetails;
using Uncos.Application.News.Commands.CreateNews;
using Uncos.Application.News.Commands.UpdateNews;
using Uncos.Application.News.Commands.DeleteNews;
using Uncos.WebAPI.Models; 
using Uncos.Domain;
using Microsoft.AspNetCore.Authorization;
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
        [Route("GetAllUserNews")]
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
        [Route("GetUserNewsById/{id}")]
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
        [Route("Create")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Guid>> Create([FromForm] CreateNewsDto createNewsDto)
        {
            var command = _mapper.Map<CreateNewsCommand>(createNewsDto); 
            command.userId = UserId;
            await Mediator.Send(command); 
            return Ok("News Created !");
        }

        [HttpPut]
        [Authorize]
        [Route("Update/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update([FromBody] UpdateNewsDto updateNewsDto)
        {
            var command = _mapper.Map<UpdateNewsCommand>(updateNewsDto); 
              command.userId = UserId;
              await Mediator.Send(command); 
            return NoContent();
        }

        [HttpDelete]
        [Authorize]
        [Route("Delete/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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
