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
using Uncos.Application.News.Queries.GetUserNewsList;
using Uncos.Application.News.Queries.GetAllNewsList;
using Uncos.Application.News.Commands.LikeNews; 
using Uncos.Application.News.Commands.SaveNews;
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
        [Route("GetAllNews")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<AllNewsListVm>> GetAllNews()
        {
            var query = new GetAllNewsQuery { };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet]
        [Authorize]
        [Route("GetAllUserNews")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<UserNewsListVm>> GetAllUserNews()
        {
            var query = new GetUserNewsListQuery
            {
                userId = UserId
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet]
        [Authorize]
        [Route("GetUserNewsById/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UserNewsListVm>> Get(Guid id)
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
        [Authorize]
        [Route("Create")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateNewsDto createNewsDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var command = _mapper.Map<CreateNewsCommand>(createNewsDto);
            command.userId = UserId;
            var result = await Mediator.Send(command);

            return Ok(result);
        }

        [HttpPost]
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
         
        [HttpPost]
        [Authorize]
        [Route("like/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> LikeNews(Guid id)
        {
            
            var command = new LikeNewsCommand
            {
                NewsId = id,
                UserId = UserId
            };

            try
            {
                await Mediator.Send(command); 
                return Ok("Liked");
            }
            catch (InvalidOperationException ex) // Для обработки отсутствия новости
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex) // Для других ошибок
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


        [HttpPost]
        [Authorize]
        [Route("save/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SaveNews(Guid id)
        {
            var command = new SaveNewsCommand
            {
                NewsId = id,
                UserId = UserId
            };

            try
            {
                await Mediator.Send(command);
                return Ok("Saved");
            }
            catch (InvalidOperationException ex) // Для обработки отсутствия новости
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex) // Для других ошибок
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }











    }

} 
